using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDB_MVC.Data
{
    public static class Database
    {
        public static SqlConnection Connection()
        {
            string connectionString = "Server=DESKTOP-6IISJCV;Database=CarDB;Integrated Security = true";
            SqlConnection con = new SqlConnection(connectionString);
            return con;
        }
        
    }
}
