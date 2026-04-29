namespace QuickMath.Domain;

/// <summary>
/// Represents the active player profile loaded from SQL.
/// </summary>
public sealed class UserProfile
{
    /// <summary>
    /// Technical primary key in the <c>qm.Users</c> table.
    /// </summary>
    public int UserId { get; init; }

    /// <summary>
    /// Display name chosen by the player.
    /// </summary>
    public string UserName { get; init; } = string.Empty;

    /// <summary>
    /// Total experience points accumulated by the player.
    /// </summary>
    public int XP { get; init; }

    /// <summary>
    /// Current coin balance available for purchases.
    /// </summary>
    public decimal Coins { get; init; }

    /// <summary>
    /// Indicates whether the profile is the currently selected mono-user profile.
    /// </summary>
    public bool IsActive { get; init; }
}
