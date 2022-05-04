using CarsDB_MVC.Common;
using CarsDB_MVC.Data;
using CarsDB_MVC.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsDB_MVC.Business
{
    class CarBusiness
    {
        ProductData productData = new ProductData();
        public void AddClient(Clients client)
        {
            productData.AddClient(client.Name,client.Surname,client.LastName);
        }
        public void AddCar(Car car)
        {
            productData.AddCar(car.Model, car.Price, car.RegNum, car.Year);
        }
        public void AddRentACar(RentACar rentACar)
        {
            productData.AddRentACar(rentACar.ClientID, rentACar.CarID);
        }
        public void ShowAllCars()
        {
            
        }
    }
}
