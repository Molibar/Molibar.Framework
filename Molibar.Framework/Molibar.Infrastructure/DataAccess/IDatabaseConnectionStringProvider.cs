namespace Molibar.Infrastructure.DataAccess
{
    public interface IDatabaseConnectionStringProvider
    {
        string ConnectionString { get; }
    }
}