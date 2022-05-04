using CarsDB_MVC.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDB_MVC.Common
{
    class Clients
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public Clients()
        {
            Name = null;
            Surname = null;
            LastName = null;
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
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
