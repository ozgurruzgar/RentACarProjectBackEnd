using Core.DataAccess.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetCarDetail();
        List<CarDetailDto> GetCarDetailByCarId(int carId);
        List<CarDetailDto> GetCarDetailByBrandId(int brandId);
        List<CarDetailDto> GetCarDetailByColorId(int colorId);
        List<CarDetailDto> GetCarDetailByColorAndBrandId(int brandId, int colorId);
    }
}
