using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetail()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                             join car in context.Cars
                             on r.CarId equals car.CarId
                             join c in context.Customers
                             on r.CustomerId equals c.UserId
                             join u in context.Users
                             on r.CustomerId equals u.Id
                             join b in context.Brands
                             on car.BrandId equals b.BrandId
                             join color in context.Colors
                             on car.ColorId equals color.ColorId
                             select new RentalDetailDto { CarName = car.Model, CustomerFullName = u.FirstName +" "+ u.LastName, Description = car.Description, ModelYear = car.ModelYear.ToString(), RentDate = r.RentDate, ReturnDate = r.ReturnDate, CarBrandName = b.BrandName, CarColorName = color.ColorName };
                return result.ToList();
            }
        }
    }
}
