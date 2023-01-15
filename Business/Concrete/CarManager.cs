using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Model.Length >= 2 && car.DailyPrice > 0)
            {
                _carDal.Add(car); Console.WriteLine("Car Added.");
            }
            else
            {
                throw new Exception("Length of Car Name small from 2 character and DailyPrice isn't big from zero.");
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetAllByDailyPrice(short min, short max)
        {
            return _carDal.GetAll(c=>c.DailyPrice >=min && c.DailyPrice <= max);
        }

        public List<Car> GetByBrandId(int BrandId)
        {
            return _carDal.GetAll(c=>c.BrandId == BrandId).ToList();
        }

        public List<Car> GetByColorId(int ColorId)
        {
            return _carDal.GetAll(c => c.ColorId == ColorId).ToList();
        }
    }
}
