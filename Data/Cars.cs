using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDB_MVC.Data
{
    class Cars
    {
        public void AddCar(string model,decimal price,int regNum,int year)
        {
            var con = Database.Connection();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into Cars(Model,Price,RegistrationNumber,Year) values (@model,@price,@regNum,@year);";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@regNum", regNum);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
