using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car> 
            {
                new Car{CarId=1,ColorId=1,BrandId=1,Model="Passat",DailyPrice=300,ModelYear=2020,Description="2020 Model Volkswagen Passat" },
                new Car{CarId=2,ColorId=2,BrandId=1,Model="Tiguan",DailyPrice=350,ModelYear=2018,Description="2018 Model Volkswagen Tiguan" },
                new Car{CarId=3,ColorId=2,BrandId=1,Model="Troc",DailyPrice=275,ModelYear=2019,Description="2019 Model Volkswagen Troc" },
                new Car{CarId=4,ColorId=3,BrandId=2,Model="3008",DailyPrice=250,ModelYear=2016,Description="2016 Model Peugeot 3008" },
                new Car{CarId=5,ColorId=3,BrandId=2,Model="2008",DailyPrice=220,ModelYear=2018,Description="2018 Model Peugeot 2008" },
            };
        }

        public void Add(Car entity)
        {
             _cars.Add(entity);
        }

        public void Delete(Car entity)
        {
            Car carToDelete = _cars.SingleOrDefault(c=>c.CarId == entity.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            var result = _cars.SingleOrDefault();
            return result;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _cars.ToList();
        }

        public void Update(Car entity)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == entity.CarId);
            carToUpdate.CarId = entity.CarId;
            carToUpdate.BrandId = entity.BrandId;
            carToUpdate.ColorId = entity.ColorId;
            carToUpdate.Model = entity.Model;
            carToUpdate.ModelYear = entity.ModelYear;
            carToUpdate.Description = entity.Description;
            carToUpdate.DailyPrice = entity.DailyPrice;
            
        }
    }
}
