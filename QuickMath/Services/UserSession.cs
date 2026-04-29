using QuickMath.Domain;

namespace QuickMath.Services;

public sealed class UserSession
{
    public UserProfile? CurrentUser { get; private set; }

    public int CurrentUserId =>
        CurrentUser?.UserId ?? throw new InvalidOperationException("No active user is loaded.");

    public void SetCurrentUser(UserProfile user)
    {
        CurrentUser = user;
    }
}
