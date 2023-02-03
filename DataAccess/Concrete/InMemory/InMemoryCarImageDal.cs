using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarImageDal : ICarImageDal
    {
        public void Add(CarImage entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(CarImage entity)
        {
            throw new NotImplementedException();
        }

        public CarImage Get(Expression<Func<CarImage, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<CarImage> GetAll(Expression<Func<CarImage, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(CarImage entity)
        {
            throw new NotImplementedException();
        }
    }
}
