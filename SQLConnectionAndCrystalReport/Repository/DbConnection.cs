using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace SQLConnectionAndCrystalReport.Repository
{
    public class DbConnection
    {
        public SqlConnection GetConnection()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["SQLDatabaseConnection"].ConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return sqlConnection;
        }
    }
}