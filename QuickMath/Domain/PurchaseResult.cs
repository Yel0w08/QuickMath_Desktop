namespace QuickMath.Domain;

/// <summary>
/// Result returned after a validated shop checkout.
/// </summary>
public sealed class PurchaseResult
{
    /// <summary>
    /// Indicates whether the purchase transaction succeeded.
    /// </summary>
    public bool Success { get; init; }

    /// <summary>
    /// User-friendly completion message shown by the UI.
    /// </summary>
    public string Message { get; init; } = string.Empty;

    /// <summary>
    /// Refreshed player snapshot after the purchase.
    /// </summary>
    public UserProfile UpdatedUser { get; init; } = new();
}
