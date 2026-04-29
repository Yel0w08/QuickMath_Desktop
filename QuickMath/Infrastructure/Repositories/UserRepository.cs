using Dapper;
using QuickMath.Domain;
using QuickMath.Infrastructure.Data;

namespace QuickMath.Infrastructure.Repositories;

/// <summary>
/// Encapsulates all SQL statements related to user profiles and active session selection.
/// </summary>
public sealed class UserRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;

    /// <summary>
    /// Creates the repository with the shared SQL connection factory.
    /// </summary>
    public UserRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    /// <summary>
    /// Returns whether the user table already contains at least one profile.
    /// </summary>
    public bool HasUsers()
    {
        using var connection = _connectionFactory.Create();
        connection.Open();
        return connection.ExecuteScalar<int>("SELECT COUNT(1) FROM qm.Users;") > 0;
    }

    /// <summary>
    /// Loads the current active user, if one has been marked as active in SQL.
    /// </summary>
    public UserProfile? GetActiveUser()
    {
        using var connection = _connectionFactory.Create();
        connection.Open();
        return connection.QuerySingleOrDefault<UserProfile>(
            """
            SELECT TOP (1) UserId, UserName, XP, Coins, IsActive
            FROM qm.Users
            WHERE IsActive = 1
            ORDER BY UserId;
            """);
    }

    /// <summary>
    /// Creates a new user or reactivates an existing one in a single transaction.
    /// </summary>
    public UserProfile CreateOrActivate(string userName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(userName);

        using var connection = _connectionFactory.Create();
        connection.Open();
        using var transaction = connection.BeginTransaction();

        // Mono-user mode means exactly one profile is active in SQL at a time.
        connection.Execute("UPDATE qm.Users SET IsActive = 0;", transaction: transaction);

        var normalizedUserName = userName.Trim();
        var userId = connection.ExecuteScalar<int?>(
            "SELECT UserId FROM qm.Users WHERE UserName = @UserName;",
            new { UserName = normalizedUserName },
            transaction);

        if (userId is null)
        {
            userId = connection.ExecuteScalar<int>(
                """
                INSERT INTO qm.Users (UserName, IsActive)
                OUTPUT INSERTED.UserId
                VALUES (@UserName, 1);
                """,
                new { UserName = normalizedUserName },
                transaction);
        }
        else
        {
            connection.Execute(
                """
                UPDATE qm.Users
                SET IsActive = 1,
                    LastPlayedUtc = SYSUTCDATETIME()
                WHERE UserId = @UserId;
                """,
                new { UserId = userId.Value },
                transaction);
        }

        transaction.Commit();
        return GetById(userId.Value);
    }

    /// <summary>
    /// Loads one user profile by primary key.
    /// </summary>
    public UserProfile GetById(int userId)
    {
        using var connection = _connectionFactory.Create();
        connection.Open();
        return connection.QuerySingle<UserProfile>(
            """
            SELECT UserId, UserName, XP, Coins, IsActive
            FROM qm.Users
            WHERE UserId = @UserId;
            """,
            new { UserId = userId });
    }
}
