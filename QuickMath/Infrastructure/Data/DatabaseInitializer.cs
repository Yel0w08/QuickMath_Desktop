using Dapper;

namespace QuickMath.Infrastructure.Data;

public sealed class DatabaseInitializer
{
    private readonly ISqlConnectionFactory _connectionFactory;

    public DatabaseInitializer(ISqlConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public void Initialize()
    {
        using var connection = _connectionFactory.Create();
        connection.Open();
        connection.Execute(SqlScripts.InitialSchema);
    }
}
