using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDB_MVC.Common
{
    class Car
    {
        public string Model { get; set; }
        public decimal Price { get; set; }
        public int RegNum { get; set; }
        public int Year { get; set; }
        public Car()
        {
            Model = null;
            Price = 0;
            RegNum = 0;
            Year = 0;

        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
