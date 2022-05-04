using System;
using System.Collections.Generic;
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
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
