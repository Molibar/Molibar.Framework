namespace Molibar.Infrastructure.DataAccess
{
    public class DatabaseConnectionStringProvider : IDatabaseConnectionStringProvider
    {
        public DatabaseConnectionStringProvider(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; private set; }
    }
}
