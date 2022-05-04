using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDB_MVC.Common
{
    class Car
    {
        public int CarID { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }
        public string RegNum { get; set; }
        public int Year { get; set; }
        public Car()
        {
            CarID = 0;
            Model = null;
            Price = 0;
            RegNum = null;
            Year = 0;

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
