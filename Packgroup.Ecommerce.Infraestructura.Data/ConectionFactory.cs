using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Packgroup.Ecommerce.Transversal.Common;

namespace Packgroup.Ecommerce.Infraestructura.Data
{
    public class ConectionFactory : IConectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IDbConnection GetConnection
        {
            get
            {
                var sqlConnection = new SqlConnection();
                if (sqlConnection == null) return null;
                sqlConnection.ConnectionString = _configuration.GetConnectionString("NorthwindConnection");
                sqlConnection.Open();
                return sqlConnection;
            }
        }
    }
}
