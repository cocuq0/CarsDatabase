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
                cmd.ExecuteNonQuery();
            }
        }
        public bool CheckIfContainsClientID(int clientID)
        {
            var con = Database.Connection();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select COUNT(ClientID) from Clients where ClientID=@id;";
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
                cmd.CommandText = "select COUNT(CarID) from Cars where CarID=@id;";
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
        public void AddCar(int carID,string model, decimal price, string regNum, int year)
        {
            var con = Database.Connection();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into Cars(CarID,Model,Price,RegNumber,Year) values (@carID,@model,@price,@regNum,@year);";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@carID",carID);
                cmd.Parameters.AddWithValue("@model", model);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@regNum", regNum);
                cmd.Parameters.AddWithValue("@year", year);
                cmd.ExecuteNonQuery();
            }
        }
        public void AddClient(int clientID, string name, string surname, string lastname)
        {
            var con = Database.Connection();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "insert into Clients(ClientID,Name,Surname,LastName) values (@clientID,@name,@surname,@lastname);";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@clientID", clientID);
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
        public void ShowAllCars()
        {
            var con = Database.Connection();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select * from Cars;";
                SqlDataReader rdr = cmd.ExecuteReader();
                Console.WriteLine(" {0} {1} {2} {3} {4}", rdr.GetName(0), rdr.GetName(1), rdr.GetName(2), rdr.GetName(3),rdr.GetName(4));
                while (rdr.Read())
                {
                    Console.WriteLine("{0} {1} {2} {3} {4}", rdr.GetValue(0), rdr.GetValue(1), rdr.GetValue(2), rdr.GetValue(3),rdr.GetValue(4));
                }
            }
        }
        public void ShowAllRentedCars()
        {
            var con = Database.Connection();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select c.CarID,c.Model,c.Price,c.RegNumber,c.Year,cl.ClientID,cl.Name,cl.LastName from Cars as c inner join Clients as cl on c.CarID = c.CarID inner join RentACar as rc on c.CarID = rc.CarID and cl.ClientID = rc.ClientID;;";
                SqlDataReader rdr = cmd.ExecuteReader();
                Console.WriteLine(" {0} {1} {2} {3} {4} {5} {6} {7}", rdr.GetName(0), rdr.GetName(1), rdr.GetName(2), rdr.GetName(3), rdr.GetName(4), rdr.GetName(5), rdr.GetName(6), rdr.GetName(7));
                while (rdr.Read())
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", rdr.GetValue(0), rdr.GetValue(1), rdr.GetValue(2), rdr.GetValue(3), rdr.GetValue(4), rdr.GetValue(5), rdr.GetValue(6), rdr.GetValue(7));
                }
            }
        }
        public void ClientsInfo(int cid)
        {
            var con = Database.Connection();
            con.Open();
            using (con)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "Select cl.ClientID,c.Model,c.Price,c.RegNumber,c.Year,cl.ClientID,cl.Name,cl.LastName from RentACar as rc inner join Clients as cl on @cid = rc.ClientID and cl.ClientID = rc.ClientID inner join Cars as c on rc.CarID = c.CarID;";
                cmd.Parameters.AddWithValue("@cid", cid);
                SqlDataReader rdr = cmd.ExecuteReader();
                Console.WriteLine(" {0} {1} {2} {3} {4} {5} {6} {7}", rdr.GetName(0), rdr.GetName(1),rdr.GetName(2), rdr.GetName(3), rdr.GetName(4), rdr.GetName(5), rdr.GetName(6), rdr.GetName(7));
                while (rdr.Read())
                {
                    Console.WriteLine("{0} {1} {2} {3} {4} {5} {6} {7}", rdr.GetValue(0), rdr.GetValue(1), rdr.GetValue(2), rdr.GetValue(3), rdr.GetValue(4), rdr.GetValue(5), rdr.GetValue(6), rdr.GetValue(7));
                }
            }
        }
    }
}
