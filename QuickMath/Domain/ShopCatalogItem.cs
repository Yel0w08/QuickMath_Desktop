namespace QuickMath.Domain;

/// <summary>
/// Shop item row prepared for display in the local WinForms shop.
/// </summary>
public sealed class ShopCatalogItem
{
    /// <summary>
    /// Technical primary key of the shop item.
    /// </summary>
    public int ShopItemId { get; init; }

    /// <summary>
    /// Stable business code used by unlock rules.
    /// </summary>
    public string ItemCode { get; init; } = string.Empty;

    /// <summary>
    /// Label shown in the shop UI.
    /// </summary>
    public string DisplayName { get; init; } = string.Empty;

    /// <summary>
    /// Coin price charged during checkout.
    /// </summary>
    public decimal PriceCoins { get; init; }

    /// <summary>
    /// Indicates whether the item can be purchased more than once.
    /// </summary>
    public bool IsRepeatable { get; init; }

    /// <summary>
    /// Indicates whether the current user already owns the item.
    /// </summary>
    public bool IsOwned { get; init; }

    /// <summary>
    /// Current owned quantity for repeatable items.
    /// </summary>
    public int QuantityOwned { get; init; }

    /// <summary>
    /// Minimum XP required before the item is visible to the user.
    /// </summary>
    public int MinimumXpRequired { get; init; }
}
