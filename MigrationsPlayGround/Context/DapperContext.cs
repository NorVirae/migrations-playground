using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace MigrationsPlayGround.Context
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_configuration.GetConnectionString("SqlConnection"));
        public NpgsqlConnection CreateMasterConnection()
             {
                Console.WriteLine(_configuration.GetConnectionString("MasterConnection"), "CHECK THIS");
            
                var conn = new NpgsqlConnection(_configuration.GetConnectionString("MasterConnection"));
                return conn;
            }
    }
}
