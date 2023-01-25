using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utitlities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            ValidationTool.Validate(new BrandValidation(), brand);
            _brandDal.Add(brand);
            return new SuccessResult(Messages.BrandAdded);
        }

        public IDataResult<Brand> GetById(int BrandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId == BrandId));
        }

        IDataResult<List<Brand>> IBrandService.GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.BrandListed);
        }
    }
}
