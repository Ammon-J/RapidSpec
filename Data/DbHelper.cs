using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
namespace RapidSpec.Data
{
    public class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=rapidspec.ch0um2aswks9.us-west-2.rds.amazonaws.com;Database=VehicleData;Integrated Security=false;User Id=admin;Password=AmmonJ123!;TrustServerCertificate=True;";
            return con;
        }
        DbHelper() { }
    }
}
