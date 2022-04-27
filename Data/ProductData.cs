using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDB_MVC.Data
{
    class ProductData
    {
        public void AddRentACar(int clientID,int carID)
        {
            var con = Database.Connection();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into RentACar(ClientID,CarID) values (@clientID,@carID);";
                cmd.Parameters.AddWithValue("@carID", carID);
                cmd.Parameters.AddWithValue("@clientID", clientID);
                cmd.Connection = con;
                if (CheckIfContainsCarID(carID) && CheckIfContainsClientID(clientID))
                {
                    cmd.ExecuteNonQuery();
                }
                else if (CheckIfContainsCarID(carID) && !CheckIfContainsClientID(clientID))
                {
                    //kogato nqma id na klient
                }
                else if (CheckIfContainsClientID(clientID) && !CheckIfContainsCarID(carID))
                {
                    //kogato nqma id na kolata
                }
                else
                {
                    //kogato nqma i dvete
                }
                
            }
        }
        public bool CheckIfContainsClientID(int clientID)
        {
            var con = Database.Connection();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select COUNT(ClientID) from RentACar where ClientID=@id;";
                cmd.Parameters.AddWithValue("@id", clientID);
                cmd.Connection = con;
                int clientCount =int.Parse(cmd.ExecuteScalar().ToString());
                if (clientCount>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool CheckIfContainsCarID(int carID)
        {
            var con = Database.Connection();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select COUNT(CarID) from RentACar where CarID=@id;";
                cmd.Parameters.AddWithValue("@id", carID);
                cmd.Connection = con;
                int carCount = int.Parse(cmd.ExecuteScalar().ToString());
                if (carCount > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
