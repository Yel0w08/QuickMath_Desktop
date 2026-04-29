using Dapper;
using QuickMath.Domain;
using QuickMath.Infrastructure.Data;

namespace QuickMath.Infrastructure.Repositories;

/// <summary>
/// Encapsulates SQL queries that aggregate player statistics for the statistics screen.
/// </summary>
public sealed class ScoreRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;

    /// <summary>
    /// Creates the repository with the shared SQL connection factory.
    /// </summary>
    public ScoreRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    /// <summary>
    /// Loads the aggregated statistics snapshot displayed by the statistics form.
    /// </summary>
    public UserStatistics GetStatistics(int userId)
    {
        using var connection = _connectionFactory.Create();
        connection.Open();

        // The statistics screen prefers one SQL roundtrip over a sequence of small
        // calls to keep the UI responsive and avoid N+1 query patterns.
        return connection.QuerySingle<UserStatistics>(
            """
            SELECT
                u.UserName,
                u.XP,
                u.Coins,
                (SELECT COUNT(1) FROM qm.ExerciseAttempts ea WHERE ea.UserId = u.UserId) AS TotalAttempts,
                (SELECT COUNT(1) FROM qm.ExerciseAttempts ea WHERE ea.UserId = u.UserId AND ea.IsCorrect = 1) AS TotalMathDone,
                (SELECT COUNT(1) FROM qm.ExerciseAttempts ea WHERE ea.UserId = u.UserId AND ea.IsCorrect = 1 AND ea.OperationId = 1) AS TotalAdditionDone,
                (SELECT COUNT(1) FROM qm.ExerciseAttempts ea WHERE ea.UserId = u.UserId AND ea.IsCorrect = 1 AND ea.OperationId = 2) AS TotalSubtractionDone,
                COALESCE((SELECT SUM(CASE WHEN cl.Amount < 0 THEN -cl.Amount ELSE 0 END) FROM qm.CoinLedger cl WHERE cl.UserId = u.UserId), 0) AS TotalCoinsSpent,
                COALESCE((SELECT SUM(CASE WHEN cl.Amount > 0 THEN cl.Amount ELSE 0 END) FROM qm.CoinLedger cl WHERE cl.UserId = u.UserId), 0) AS TotalCoinsEarned,
                COALESCE((SELECT SUM(cl.Amount) FROM qm.CoinLedger cl WHERE cl.UserId = u.UserId), 0) AS NetCoins,
                COALESCE(
                    (
                        SELECT CAST(AVG(CAST(ea.AwardedXp AS DECIMAL(10,2))) AS DECIMAL(10,2))
                        FROM qm.ExerciseAttempts ea
                        WHERE ea.UserId = u.UserId
                          AND ea.IsCorrect = 1
                    ),
                    0
                ) AS AverageXpPerCorrectAnswer,
                COALESCE(
                    (
                        SELECT CAST(AVG(ea.AwardedCoins) AS DECIMAL(10,2))
                        FROM qm.ExerciseAttempts ea
                        WHERE ea.UserId = u.UserId
                          AND ea.IsCorrect = 1
                    ),
                    0
                ) AS AverageCoinsPerCorrectAnswer,
                COALESCE(
                    (
                        SELECT SUM(ui.Quantity)
                        FROM qm.UserInventory ui
                        INNER JOIN qm.ShopItems si ON si.ShopItemId = ui.ShopItemId
                        WHERE ui.UserId = u.UserId
                          AND si.ShopCategoryId = 1
                    ),
                    0
                ) AS DifficultyUnlocksOwned,
                COALESCE((SELECT SUM(ui.Quantity) FROM qm.UserInventory ui WHERE ui.UserId = u.UserId), 0) AS TotalCollectibles,
                COALESCE((SELECT SUM(ui.Quantity) FROM qm.UserInventory ui INNER JOIN qm.ShopItems si ON si.ShopItemId = ui.ShopItemId WHERE ui.UserId = u.UserId AND si.ItemCode = N'red-star'), 0) AS RedStars,
                COALESCE((SELECT SUM(ui.Quantity) FROM qm.UserInventory ui INNER JOIN qm.ShopItems si ON si.ShopItemId = ui.ShopItemId WHERE ui.UserId = u.UserId AND si.ItemCode = N'blue-star'), 0) AS BlueStars,
                COALESCE((SELECT SUM(ui.Quantity) FROM qm.UserInventory ui INNER JOIN qm.ShopItems si ON si.ShopItemId = ui.ShopItemId WHERE ui.UserId = u.UserId AND si.ItemCode = N'yellow-star'), 0) AS YellowStars,
                COALESCE((SELECT SUM(ui.Quantity) FROM qm.UserInventory ui INNER JOIN qm.ShopItems si ON si.ShopItemId = ui.ShopItemId WHERE ui.UserId = u.UserId AND si.ItemCode = N'purple-star'), 0) AS PurpleStars,
                COALESCE((SELECT SUM(ui.Quantity) FROM qm.UserInventory ui INNER JOIN qm.ShopItems si ON si.ShopItemId = ui.ShopItemId WHERE ui.UserId = u.UserId AND si.ItemCode = N'dark-matter'), 0) AS DarkMatter
            FROM qm.Users u
            WHERE u.UserId = @UserId;
            """,
            new { UserId = userId });
    }
}
