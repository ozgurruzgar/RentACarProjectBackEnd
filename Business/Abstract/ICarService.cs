using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetByBrandId(int BrandId);
        List<Car> GetByColorId(int ColorId);
        List<Car> GetAllByDailyPrice(short min,short max);
        void Add(Car car);
    }
}
