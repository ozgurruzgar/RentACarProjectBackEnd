    using Core.Utitlities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetByBrandId(int BrandId);
        IDataResult<List<Car>> GetByColorId(int ColorId);
        IDataResult<List<Car>> GetAllByDailyPrice(short min,short max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IDataResult<Car> GetById(int CarId);
        IResult Add(Car car);
        IResult AddTransactionalTest(Car car);
    }
}
