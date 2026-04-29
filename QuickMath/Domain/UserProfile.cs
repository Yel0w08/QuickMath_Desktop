namespace QuickMath.Domain;

public sealed class UserProfile
{
    public int UserId { get; init; }
    public string UserName { get; init; } = string.Empty;
    public int XP { get; init; }
    public decimal Coins { get; init; }
    public bool IsActive { get; init; }
}
