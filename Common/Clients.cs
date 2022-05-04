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
        public int ClientID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string LastName { get; set; }
        public Clients()
        {
            ClientID = 0;
            Name = null;
            Surname = null;
            LastName = null;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
