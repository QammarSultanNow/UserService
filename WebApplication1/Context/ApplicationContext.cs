using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Context
{
    public class ApplicationContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;

        public ApplicationContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaullConnection");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
