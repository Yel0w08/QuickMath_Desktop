using Dapper;
using QuickMath.Domain;
using QuickMath.Infrastructure.Data;

namespace QuickMath.Infrastructure.Repositories;

/// <summary>
/// Encapsulates all SQL access for the local in-game shop.
/// </summary>
public sealed class ShopRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public ShopRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    /// <summary>
    /// Returns the SQL-backed catalog visible to the current player for one category.
    /// </summary>
    public IReadOnlyList<ShopCatalogItem> GetCatalog(int userId, ShopCategory category)
    {
        using var connection = _connectionFactory.Create();
        connection.Open();

        return connection.Query<ShopCatalogItem>(
            """
            SELECT
                si.ShopItemId,
                si.ItemCode,
                si.DisplayName,
                si.PriceCoins,
                si.IsRepeatable,
                si.MinimumXpRequired,
                CAST(CASE WHEN COALESCE(ui.Quantity, 0) > 0 THEN 1 ELSE 0 END AS bit) AS IsOwned,
                COALESCE(ui.Quantity, 0) AS QuantityOwned
            FROM qm.ShopItems si
            INNER JOIN qm.Users u ON u.UserId = @UserId
            LEFT JOIN qm.UserInventory ui
                ON ui.UserId = u.UserId
               AND ui.ShopItemId = si.ShopItemId
            WHERE si.ShopCategoryId = @CategoryId
              AND u.XP >= si.MinimumXpRequired
            ORDER BY si.PriceCoins, si.DisplayName;
            """,
            new { UserId = userId, CategoryId = (int)category }).AsList();
    }

    public PurchaseResult Purchase(int userId, IReadOnlyCollection<int> shopItemIds)
    {
        if (shopItemIds.Count == 0)
        {
            throw new InvalidOperationException("Your cart is empty.");
        }

        using var connection = _connectionFactory.Create();
        connection.Open();
        using var transaction = connection.BeginTransaction();

        var user = connection.QuerySingle<UserProfile>(
            """
            SELECT UserId, UserName, XP, Coins, IsActive
            FROM qm.Users
            WHERE UserId = @UserId;
            """,
            new { UserId = userId },
            transaction);

        var items = connection.Query<ShopCatalogItem>(
            """
            SELECT
                si.ShopItemId,
                si.ItemCode,
                si.DisplayName,
                si.PriceCoins,
                si.IsRepeatable,
                si.MinimumXpRequired,
                CAST(CASE WHEN COALESCE(ui.Quantity, 0) > 0 THEN 1 ELSE 0 END AS bit) AS IsOwned,
                COALESCE(ui.Quantity, 0) AS QuantityOwned
            FROM qm.ShopItems si
            LEFT JOIN qm.UserInventory ui
                ON ui.ShopItemId = si.ShopItemId
               AND ui.UserId = @UserId
            WHERE si.ShopItemId IN @ShopItemIds;
            """,
            new { UserId = userId, ShopItemIds = shopItemIds.ToArray() },
            transaction).ToList();

        if (items.Count != shopItemIds.Count)
        {
            throw new InvalidOperationException("Some selected shop items do not exist anymore.");
        }

        foreach (var item in items)
        {
            if (user.XP < item.MinimumXpRequired)
            {
                throw new InvalidOperationException($"You need at least {item.MinimumXpRequired} XP to buy {item.DisplayName}.");
            }

            if (!item.IsRepeatable && item.IsOwned)
            {
                throw new InvalidOperationException($"{item.DisplayName} is already owned.");
            }
        }

        var total = items.Sum(static item => item.PriceCoins);
        if (user.Coins < total)
        {
            throw new InvalidOperationException($"Not enough coins. Missing {total - user.Coins:0.##}.");
        }

        connection.Execute(
            """
            UPDATE qm.Users
            SET Coins = Coins - @Total
            WHERE UserId = @UserId;
            """,
            new { UserId = userId, Total = total },
            transaction);

        foreach (var item in items)
        {
            // Inventory updates are idempotent at the SQL level: unique ownership
            // for unlocks, quantity increments for repeatable collectibles.
            connection.Execute(
                """
                MERGE qm.UserInventory AS target
                USING (SELECT @UserId AS UserId, @ShopItemId AS ShopItemId) AS source
                    ON target.UserId = source.UserId
                   AND target.ShopItemId = source.ShopItemId
                WHEN MATCHED THEN
                    UPDATE SET Quantity = target.Quantity + 1, AcquiredUtc = SYSUTCDATETIME()
                WHEN NOT MATCHED THEN
                    INSERT (UserId, ShopItemId, Quantity)
                    VALUES (source.UserId, source.ShopItemId, 1);
                """,
                new { UserId = userId, item.ShopItemId },
                transaction);
        }

        connection.Execute(
            """
            INSERT INTO qm.CoinLedger (UserId, Amount, EntryType, ReferenceCode)
            VALUES (@UserId, @Amount, N'shop-purchase', @ReferenceCode);
            """,
            new
            {
                UserId = userId,
                Amount = -total,
                ReferenceCode = string.Join(",", items.Select(static item => item.ItemCode)),
            },
            transaction);

        transaction.Commit();

        var updatedUser = connection.QuerySingle<UserProfile>(
            """
            SELECT UserId, UserName, XP, Coins, IsActive
            FROM qm.Users
            WHERE UserId = @UserId;
            """,
            new { UserId = userId });

        return new PurchaseResult
        {
            Success = true,
            Message = $"Purchase completed for {items.Count} item(s).",
            UpdatedUser = updatedUser,
        };
    }
}
