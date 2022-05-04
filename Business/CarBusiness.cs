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
            productData.AddClient(client.ClientID, client.Name,client.Surname,client.LastName);
        }
        public void AddCar(Car car)
        {
            productData.AddCar(car.CarID, car.Model, car.Price, car.RegNum, car.Year);
        }
        public void AddRentACar(int clientId, int carId)
        {
            productData.AddRentACar(clientId, carId);
        }
        public bool CheckIfContainsClientID(int clientID)
        {
            return productData.CheckIfContainsClientID(clientID);
        }
        public bool CheckIfContainsCarID(int carID)
        {
            return productData.CheckIfContainsCarID(carID);
        }
        public void ShowAllCars()
        {
            
        }
    }
}
