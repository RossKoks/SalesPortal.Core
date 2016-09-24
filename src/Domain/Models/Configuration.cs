namespace SalesPortal.Core.Models
{
    public class Configuration
    {
        public string ConnectionString { get; }

        public Configuration(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}