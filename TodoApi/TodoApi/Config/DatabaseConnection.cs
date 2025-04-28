using System.Data.SqlClient;

namespace TodoApi.Config
{
    public class DatabaseConnection
    {
        private readonly string _connectionString;

        public DatabaseConnection(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("AccessConnection").ToString();
        } 

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
