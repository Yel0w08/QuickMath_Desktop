namespace QuickMath.Domain;

public sealed class ShopCatalogItem
{
    public int ShopItemId { get; init; }
    public string ItemCode { get; init; } = string.Empty;
    public string DisplayName { get; init; } = string.Empty;
    public decimal PriceCoins { get; init; }
    public bool IsRepeatable { get; init; }
    public bool IsOwned { get; init; }
    public int QuantityOwned { get; init; }
    public int MinimumXpRequired { get; init; }
}
