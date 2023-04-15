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
        IDataResult<List<CarDetailDto>> GetCarDetail();
        IDataResult<List<CarDetailDto>> GetCarDetailByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetailByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetCarDetailByColorId(int colorId);
        IDataResult<List<CarDetailDto>> GetCarDetailByColorAndBrandId(int brandId, int colorId);
        IDataResult<List<Car>> GetAllByDailyPrice(short min,short max);
        IResult Add(Car car);
        IResult AddTransactionalTest(Car car);
    }
}
