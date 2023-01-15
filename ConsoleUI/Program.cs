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
            Car car = new Car() {CarId=1,BrandId=1,ColorId=1,Model="Passat Variant",DailyPrice=300,ModelYear=2020,Description="2020 Model Volkswagen Passat Variant" };
            Car car2 = new Car() { CarId = 2, BrandId = 1, ColorId = 1, Model = "Tiguan", DailyPrice = 350, ModelYear = 2018, Description = "2018 Model Volkswagen Tiguan " };
            Car car3 = new Car() {CarId=3,BrandId=2,ColorId=2,Model= "3008", DailyPrice=250,ModelYear=2016,Description="2016 Model Peugeot 3008 " };

            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(car);
            carManager.Add(car2);
            carManager.Add(car3);

            foreach (var carr in carManager.GetAll())
            {
                Console.WriteLine(carr.Model +" "+ carr.Description);
            }
        }
    }
}
