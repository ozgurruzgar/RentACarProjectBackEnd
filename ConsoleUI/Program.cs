using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            // CreateCarAndList();
            // CreateCustomerAndList();
            CreatRentalAndList();

        }
        private static void CreatRentalAndList()
        {
            Rental rental = new Rental { RentalId=1,CarId = 1,CustomerId=1, };
            Rental rental2 = new Rental { RentalId=2,CarId = 3,CustomerId=3,ReturnDate=new System.DateTime(2023, 01,25) };
            Rental rental3 = new Rental { RentalId=3,CarId = 2,CustomerId=2,ReturnDate=new System.DateTime(2023, 01,23) };

            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            rentalManager.Add(rental);
            rentalManager.Add(rental2);
            rentalManager.Add(rental3);

            var result = rentalManager.GetAll();

            if (result.Success == true)
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.RentalId + " Customer= " + c.CustomerId + " CarId="+c.CarId);
                }
            else
                Console.WriteLine(result.Message);
        }
        private static void CreateCustomerAndList()
        {
            Customer customer = new Customer {UserId=1,CompanyName="Kodlama.io" };
            Customer customer2 = new Customer {UserId=2,CompanyName="Hepsiburada" };
            Customer customer3 = new Customer {UserId=3,CompanyName= "Trendyol" };

            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(customer);
            customerManager.Add(customer2);
            customerManager.Add(customer3);

            var result = customerManager.GetAll();

            if (result.Success == true)
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.CompanyName + " \n");
                }
            else
                Console.WriteLine(result.Message);
        }

        private static void CreateCarAndList()
        {
            Car car = new Car() { CarId = 1, BrandId = 1, ColorId = 1, Model = "Passat Variant", DailyPrice = 300, ModelYear = 2020, Description = "2020 Model Volkswagen Passat Variant" };
            Car car2 = new Car() { CarId = 2, BrandId = 1, ColorId = 1, Model = "Tiguan", DailyPrice = 350, ModelYear = 2018, Description = "2018 Model Volkswagen Tiguan " };
            Car car3 = new Car() { CarId = 3, BrandId = 2, ColorId = 2, Model = "3008", DailyPrice = 250, ModelYear = 2016, Description = "2016 Model Peugeot 3008 " };

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car);
            carManager.Add(car2);
            carManager.Add(car3);

            var result = carManager.GetAll();

            if (result.Success == true)
            {
                foreach (var c in result.Data)
                {
                    Console.WriteLine(c.Model + " " + c.ModelYear + " " + c.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
