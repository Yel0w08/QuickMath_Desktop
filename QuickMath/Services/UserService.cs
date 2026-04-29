using QuickMath.Domain;
using QuickMath.Infrastructure.Repositories;

namespace QuickMath.Services;

public sealed class UserService
{
    private readonly UserRepository _userRepository;
    private readonly UserSession _userSession;

    public UserService(UserRepository userRepository, UserSession userSession)
    {
        _userRepository = userRepository;
        _userSession = userSession;
    }

    public bool HasRegisteredUsers() => _userRepository.HasUsers();

    public UserProfile EnsureActiveUser()
    {
        var user = _userRepository.GetActiveUser()
            ?? throw new InvalidOperationException("No active user found. Complete registration first.");

        _userSession.SetCurrentUser(user);
        return user;
    }

    public UserProfile RegisterOrActivate(string userName)
    {
        var user = _userRepository.CreateOrActivate(userName);
        _userSession.SetCurrentUser(user);
        return user;
    }

    public UserProfile RefreshCurrentUser()
    {
        var user = _userRepository.GetById(_userSession.CurrentUserId);
        _userSession.SetCurrentUser(user);
        return user;
    }
}
