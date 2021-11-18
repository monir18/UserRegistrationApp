using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistrationApp.DBManager
{
    public class ConnectionManager
    {
        public static string conStr;
        public static SqlConnection GetConnection()
        {
            try
            {
                SqlConnection connection = new SqlConnection(conStr);
                return connection;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        //public static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyCon"].ConnectionString);
    }
}
//using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DevConnection")))

