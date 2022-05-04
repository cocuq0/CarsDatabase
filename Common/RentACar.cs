using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDB_MVC.Common
{
    class RentACar
    {
        public int ClientID { get; set; }
        public int CarID { get; set; }
        public RentACar()
        {
            ClientID = 0;
            CarID = 0;
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
