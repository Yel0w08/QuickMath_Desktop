using QuickMath.Domain;

namespace QuickMath.Services;

/// <summary>
/// Keeps the active local user in memory for the lifetime of the desktop process.
/// </summary>
public sealed class UserSession
{
    /// <summary>
    /// Current user snapshot or <see langword="null"/> before registration/login completes.
    /// </summary>
    public UserProfile? CurrentUser { get; private set; }

    /// <summary>
    /// Returns the active user identifier required by repositories and services.
    /// </summary>
    public int CurrentUserId =>
        CurrentUser?.UserId ?? throw new InvalidOperationException("No active user is loaded.");

    /// <summary>
    /// Replaces the cached in-memory snapshot after a SQL-backed operation.
    /// </summary>
    public void SetCurrentUser(UserProfile user)
    {
        CurrentUser = user;
    }
}
