namespace QuickMath.Domain;

public sealed class PurchaseResult
{
    public bool Success { get; init; }
    public string Message { get; init; } = string.Empty;
    public UserProfile UpdatedUser { get; init; } = new();
}
