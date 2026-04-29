using Microsoft.Data.SqlClient;

namespace QuickMath.Infrastructure.Data;

/// <summary>
/// Creates SQL Server LocalDB connections for the local QuickMath database.
/// </summary>
public sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private const string LocalDbInstance = @"(LocalDB)\MSSQLLocalDB";
    private const string DatabaseName = "QuickMath_Local";
    private readonly string _applicationDataDirectory;
    private readonly string _databaseFilePath;
    private readonly string _databaseLogFilePath;
    private readonly string _connectionString;

    public SqlConnectionFactory()
    {
        // The whole application runs in a mono-user local mode: the SQL Server
        // database files live inside the current Windows profile.
        _applicationDataDirectory = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "QuickMath");

        _databaseFilePath = Path.Combine(_applicationDataDirectory, $"{DatabaseName}.mdf");
        _databaseLogFilePath = Path.Combine(_applicationDataDirectory, $"{DatabaseName}_log.ldf");

        _connectionString = new SqlConnectionStringBuilder
        {
            DataSource = LocalDbInstance,
            InitialCatalog = DatabaseName,
            IntegratedSecurity = true,
            Encrypt = false,
            TrustServerCertificate = true,
            ConnectTimeout = 30,
        }.ConnectionString;
    }

    public SqlConnection Create() => new(_connectionString);

    /// <summary>
    /// Creates a connection to the <c>master</c> catalog used only for database bootstrap.
    /// </summary>
    public SqlConnection CreateMasterConnection()
    {
        // LocalDB requires a connection to master before creating the per-user database.
        var builder = new SqlConnectionStringBuilder(_connectionString)
        {
            InitialCatalog = "master"
        };

        return new SqlConnection(builder.ConnectionString);
    }

    /// <summary>
    /// Directory used to store the local MDF and LDF files.
    /// </summary>
    public string ApplicationDataDirectory => _applicationDataDirectory;

    /// <summary>
    /// Full path to the local MDF file.
    /// </summary>
    public string DatabaseFilePath => _databaseFilePath;

    /// <summary>
    /// Full path to the local SQL Server log file.
    /// </summary>
    public string DatabaseLogFilePath => _databaseLogFilePath;
}
