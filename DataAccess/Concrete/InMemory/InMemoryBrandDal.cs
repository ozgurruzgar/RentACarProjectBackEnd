using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        List<Brand> _brands;

        public InMemoryBrandDal(List<Brand> brands)
        {
            _brands = new List<Brand> 
            {
                new Brand{BrandId=1,BrandName="Volkswagen" },
                new Brand{BrandId=2,BrandName="Peugeot" },
                new Brand{BrandId=3,BrandName="Fiat" },
                new Brand{BrandId=4,BrandName="Ford" },
            };
        }

        public void Add(Brand entity)
        {
            _brands.Add(entity);
        }

        public void Delete(Brand entity)
        {
            Brand brandToDelete = _brands.SingleOrDefault(b => b.BrandId == entity.BrandId);
            _brands.Remove(entity);
        }

        public Brand Get(Expression<Func<Brand, bool>> filter)
        {
            var result = _brands.SingleOrDefault();
            return result;
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return _brands.ToList();
        }

        public void Update(Brand entity)
        {
            Brand brandToUpdate = _brands.SingleOrDefault(b => b.BrandId == entity.BrandId);
            brandToUpdate.BrandId = entity.BrandId;
            brandToUpdate.BrandName = entity.BrandName;
        }
    }
}
