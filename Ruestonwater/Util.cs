using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Ruestonwater
{
    public class Util
    {
        public static void ExecuteQuery(string command)
        {
            SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SQLConnectionString"].ConnectionString);
            sqlConnection.Open();
            SqlCommand cmd = new SqlCommand(command, sqlConnection);
            cmd.ExecuteNonQuery();
            sqlConnection.Close();
        }
    }
}