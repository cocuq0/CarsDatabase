using CarsDB_MVC.Business;
using CarsDB_MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarsDB_MVC.Common;

namespace CarsDB_MVC.Presentation
{
    class Display
    {
        private int menuInput;
        CarBusiness carBusiness = new CarBusiness();
        public Display()
        {
            ShowMenu();
        }
        public void ShowMenu()
        {
            Console.WriteLine(new string('-',40));
            Console.WriteLine(new string(' ',18) + "MENU" + new string(' ',18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1 - Add new rented car");
            Console.WriteLine("2 - Add new client");
            Console.WriteLine("3 - Add new car");
            Console.WriteLine("Press 0 to exit");
            menuInput = int.Parse(Console.ReadLine());
            MenuInteraction(menuInput);
        }
        public void MenuInteraction(int input)
        {
            switch (input)
            {
                default:
                    break;
                case 1:
                    AddCar();
                    ShowMenu();
                    break;
                case 2:
                    AddClient();
                    ShowMenu();
                    break;
                case 3:
                    AddRentACar();
                    ShowMenu();
                    break;
                case 0:
                    break;
            }
            
        }
        public void AddClient()
        {
            Clients client = new Clients();
            Console.WriteLine("Enter the name of the client");
            client.Name = Console.ReadLine();
            Console.WriteLine("Enter the surname of the client");
            client.Surname = Console.ReadLine();
            Console.WriteLine("Enter the last name of the client");
            client.LastName = Console.ReadLine();
            carBusiness.AddClient(client);
        }
        public void AddCar()
        {
            Car car = new Car();
            Console.WriteLine("Enter the model of the car");
            car.Model = Console.ReadLine();
            Console.WriteLine("Enter the price of the car");
            car.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter the registration number of the car");
            car.RegNum = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the production year of the car");
            car.Year = int.Parse(Console.ReadLine());
            carBusiness.AddCar(car);
        }
        public void AddRentACar()
        {
            RentACar rentACar = new RentACar();
            Console.WriteLine("Enter Client ID");
            rentACar.ClientID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Car ID");
            rentACar.CarID = int.Parse(Console.ReadLine());
            carBusiness.AddRentACar(rentACar);
        }
    }
}
