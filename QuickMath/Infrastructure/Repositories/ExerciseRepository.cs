using Dapper;
using QuickMath.Domain;
using QuickMath.Infrastructure.Data;

namespace QuickMath.Infrastructure.Repositories;

public sealed class ExerciseRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public ExerciseRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public DifficultyDefinition GetDifficultyForUser(int userId, MathOperation operation, DifficultyLevel difficulty)
    {
        using var connection = _connectionFactory.Create();
        connection.Open();

        var record = connection.QuerySingle(
            """
            SELECT
                d.MinOperand,
                d.MaxOperand,
                d.RewardXp,
                d.RewardCoins,
                d.RequiredItemCode,
                CASE
                    WHEN d.RequiredItemCode IS NULL THEN CAST(1 AS bit)
                    WHEN EXISTS (
                        SELECT 1
                        FROM qm.UserInventory ui
                        INNER JOIN qm.ShopItems si ON si.ShopItemId = ui.ShopItemId
                        WHERE ui.UserId = @UserId
                          AND si.ItemCode = d.RequiredItemCode
                          AND ui.Quantity > 0
                    ) THEN CAST(1 AS bit)
                    ELSE CAST(0 AS bit)
                END AS IsUnlocked
            FROM qm.DifficultyLevels d
            WHERE d.OperationId = @OperationId
              AND d.DifficultyCode = @DifficultyCode;
            """,
            new
            {
                UserId = userId,
                OperationId = (int)operation,
                DifficultyCode = DifficultyCodeMapper.ToCode(difficulty),
            });

        return new DifficultyDefinition
        {
            Operation = operation,
            Difficulty = difficulty,
            MinOperand = record.MinOperand,
            MaxOperand = record.MaxOperand,
            RewardXp = record.RewardXp,
            RewardCoins = record.RewardCoins,
            RequiredItemCode = record.RequiredItemCode,
            IsUnlocked = record.IsUnlocked,
        };
    }

    public ExerciseSubmissionResult SaveAttempt(int userId, ExerciseProblem problem, int submittedAnswer)
    {
        var isCorrect = submittedAnswer == problem.ExpectedAnswer;

        using var connection = _connectionFactory.Create();
        connection.Open();
        using var transaction = connection.BeginTransaction();

        var difficultyRecord = connection.QuerySingle(
            """
            SELECT DifficultyLevelId, RewardXp, RewardCoins
            FROM qm.DifficultyLevels
            WHERE OperationId = @OperationId
              AND DifficultyCode = @DifficultyCode;
            """,
            new
            {
                OperationId = (int)problem.Operation,
                DifficultyCode = DifficultyCodeMapper.ToCode(problem.Difficulty),
            },
            transaction);

        var awardedXp = isCorrect ? (int)difficultyRecord.RewardXp : 0;
        var awardedCoins = isCorrect ? (decimal)difficultyRecord.RewardCoins : 0m;

        connection.Execute(
            """
            INSERT INTO qm.ExerciseAttempts
            (
                UserId,
                OperationId,
                DifficultyLevelId,
                LeftOperand,
                RightOperand,
                ExpectedAnswer,
                SubmittedAnswer,
                IsCorrect,
                AwardedXp,
                AwardedCoins
            )
            VALUES
            (
                @UserId,
                @OperationId,
                @DifficultyLevelId,
                @LeftOperand,
                @RightOperand,
                @ExpectedAnswer,
                @SubmittedAnswer,
                @IsCorrect,
                @AwardedXp,
                @AwardedCoins
            );
            """,
            new
            {
                UserId = userId,
                OperationId = (int)problem.Operation,
                DifficultyLevelId = (int)difficultyRecord.DifficultyLevelId,
                problem.LeftOperand,
                problem.RightOperand,
                problem.ExpectedAnswer,
                SubmittedAnswer = submittedAnswer,
                IsCorrect = isCorrect,
                AwardedXp = awardedXp,
                AwardedCoins = awardedCoins,
            },
            transaction);

        if (isCorrect)
        {
            connection.Execute(
                """
                UPDATE qm.Users
                SET XP = XP + @AwardedXp,
                    Coins = Coins + @AwardedCoins,
                    LastPlayedUtc = SYSUTCDATETIME()
                WHERE UserId = @UserId;
                """,
                new { UserId = userId, AwardedXp = awardedXp, AwardedCoins = awardedCoins },
                transaction);

            connection.Execute(
                """
                INSERT INTO qm.CoinLedger (UserId, Amount, EntryType, ReferenceCode)
                VALUES (@UserId, @Amount, N'exercise-reward', @ReferenceCode);
                """,
                new
                {
                    UserId = userId,
                    Amount = awardedCoins,
                    ReferenceCode = $"{problem.Operation}:{problem.Difficulty}",
                },
                transaction);
        }

        transaction.Commit();

        var user = connection.QuerySingle<UserProfile>(
            """
            SELECT UserId, UserName, XP, Coins, IsActive
            FROM qm.Users
            WHERE UserId = @UserId;
            """,
            new { UserId = userId });

        return new ExerciseSubmissionResult
        {
            IsCorrect = isCorrect,
            AwardedXp = awardedXp,
            AwardedCoins = awardedCoins,
            UpdatedUser = user,
        };
    }
}
