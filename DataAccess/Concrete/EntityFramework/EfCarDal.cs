using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwinContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetail()
        {
            using (NorthwinContext context = new NorthwinContext())
            {
                var result = from car in context.Cars
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join c in context.Colors
                             on car.ColorId equals c.ColorId
                             select new CarDetailDto {CarName=car.Model,BrandName=b.BrandName,ColorName=c.ColorName,DailyPrice=car.DailyPrice };
                
                return result.ToList();
            }
        }
    }
}
