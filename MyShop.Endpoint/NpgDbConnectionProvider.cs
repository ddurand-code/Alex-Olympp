using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MyShop.Endpoint.Ports;
using Npgsql;

namespace MyShop.Endpoint
{
    public class NpgDbConnectionProvider : ISqlDbConnectionProvider
    {
        private readonly string? _connectionString;

        public NpgDbConnectionProvider(IConfiguration config)
        {
            _connectionString = config.GetValue<string>("ConnectionStrings:postgresdb");
        }

        public DbConnection GetSqlConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }
    }
}
