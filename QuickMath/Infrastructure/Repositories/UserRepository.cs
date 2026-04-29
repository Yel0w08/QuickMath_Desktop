using Dapper;
using QuickMath.Domain;
using QuickMath.Infrastructure.Data;

namespace QuickMath.Infrastructure.Repositories;

public sealed class UserRepository
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public UserRepository(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public bool HasUsers()
    {
        using var connection = _connectionFactory.Create();
        connection.Open();
        return connection.ExecuteScalar<int>("SELECT COUNT(1) FROM qm.Users;") > 0;
    }

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

    public UserProfile CreateOrActivate(string userName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(userName);

        using var connection = _connectionFactory.Create();
        connection.Open();
        using var transaction = connection.BeginTransaction();

        connection.Execute("UPDATE qm.Users SET IsActive = 0;", transaction: transaction);

        var userId = connection.ExecuteScalar<int?>(
            "SELECT UserId FROM qm.Users WHERE UserName = @UserName;",
            new { UserName = userName.Trim() },
            transaction);

        if (userId is null)
        {
            userId = connection.ExecuteScalar<int>(
                """
                INSERT INTO qm.Users (UserName, IsActive)
                OUTPUT INSERTED.UserId
                VALUES (@UserName, 1);
                """,
                new { UserName = userName.Trim() },
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
