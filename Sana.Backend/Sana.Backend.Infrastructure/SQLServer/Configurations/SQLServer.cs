namespace Sana.Backend.Infrastructure.SQLServer.Configurations
{
    public class SQLServer : IConfigurateSQLServer
    {
        public string ConnectionString { get; set; } = string.Empty;
    }
    public interface IConfigurateSQLServer
    {
        string ConnectionString { get; set; }
    }
}
