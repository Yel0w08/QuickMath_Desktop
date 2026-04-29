using Dapper;
using QuickMath.Domain;
using QuickMath.Infrastructure.Data;

namespace QuickMath.Infrastructure.Repositories;

public sealed class ScoreRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public ScoreRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public UserStatistics GetStatistics(int userId)
    {
        using var connection = _connectionFactory.Create();
        connection.Open();

        return connection.QuerySingle<UserStatistics>(
            """
            SELECT
                u.UserName,
                u.XP,
                u.Coins,
                (SELECT COUNT(1) FROM qm.ExerciseAttempts ea WHERE ea.UserId = u.UserId AND ea.IsCorrect = 1) AS TotalMathDone,
                (SELECT COUNT(1) FROM qm.ExerciseAttempts ea WHERE ea.UserId = u.UserId AND ea.IsCorrect = 1 AND ea.OperationId = 1) AS TotalAdditionDone,
                (SELECT COUNT(1) FROM qm.ExerciseAttempts ea WHERE ea.UserId = u.UserId AND ea.IsCorrect = 1 AND ea.OperationId = 2) AS TotalSubtractionDone,
                COALESCE((SELECT SUM(CASE WHEN cl.Amount < 0 THEN -cl.Amount ELSE 0 END) FROM qm.CoinLedger cl WHERE cl.UserId = u.UserId), 0) AS TotalCoinsSpent,
                COALESCE((SELECT SUM(CASE WHEN cl.Amount > 0 THEN cl.Amount ELSE 0 END) FROM qm.CoinLedger cl WHERE cl.UserId = u.UserId), 0) AS TotalCoinsEarned,
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
