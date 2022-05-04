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
        public void AddCar(string model, decimal price, int regNum, int year)
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
        public void AddClient(string name, string surname, string lastname)
        {
            var con = Database.Connection();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into Clients(Name,Surname,LastName) values (@name,@surname,@lastname);";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@surname", surname);
                cmd.Parameters.AddWithValue("@lastname", lastname);
                cmd.ExecuteNonQuery();
            }
        }
        public void ShowAllClients()
        {
            var con = Database.Connection();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Clients;";
                SqlDataReader rdr = cmd.ExecuteReader();
                Console.WriteLine(" {0} {1} {2} {3}",rdr.GetName(0), rdr.GetName(1), rdr.GetName(2),rdr.GetName(3));
                while (rdr.Read())
                {
                    Console.WriteLine("{0} {1} {2} {3}", rdr.GetValue(0), rdr.GetValue(1), rdr.GetValue(2), rdr.GetValue(3));
                }
            }
        }
    }
}
