using QuickMath.Domain;
using QuickMath.Infrastructure.Repositories;

namespace QuickMath.Services;

/// <summary>
/// Coordinates user lifecycle concerns between forms and repositories.
/// </summary>
public sealed class UserService
{
    private readonly UserRepository _userRepository;
    private readonly UserSession _userSession;

    /// <summary>
    /// Creates the service with its backing repository and session cache.
    /// </summary>
    public UserService(UserRepository userRepository, UserSession userSession)
    {
        _userRepository = userRepository;
        _userSession = userSession;
    }

    /// <summary>
    /// Indicates whether at least one user profile already exists in SQL.
    /// </summary>
    public bool HasRegisteredUsers() => _userRepository.HasUsers();

    /// <summary>
    /// Loads the active user from SQL and stores it in the in-memory session cache.
    /// </summary>
    public UserProfile EnsureActiveUser()
    {
        var user = _userRepository.GetActiveUser()
            ?? throw new InvalidOperationException("No active user found. Complete registration first.");

        _userSession.SetCurrentUser(user);
        return user;
    }

    /// <summary>
    /// Creates a new user or reactivates an existing one, then updates the local session snapshot.
    /// </summary>
    public UserProfile RegisterOrActivate(string userName)
    {
        var user = _userRepository.CreateOrActivate(userName);
        _userSession.SetCurrentUser(user);
        return user;
    }

    /// <summary>
    /// Reloads the current user from SQL after a business operation changed the persisted state.
    /// </summary>
    public UserProfile RefreshCurrentUser()
    {
        var user = _userRepository.GetById(_userSession.CurrentUserId);
        _userSession.SetCurrentUser(user);
        return user;
    }
}
