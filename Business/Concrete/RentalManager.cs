using Business.Abstract;
using Business.Contants;
using Business.ValidationRules.FluentValidation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utitlities.Business;
using Core.Utitlities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            IResult result = BusinessRules.Run(CheckCarAvaible(rental.CarId));
            if(result!=null)
            {
                return result;
            }
            ValidationTool.Validate(new RentalValidation(),rental);
            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int RentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r => r.RentalId == RentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetail()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetail());
        }

        private IResult CheckIfCarAvaibleForRent(int carId)
        {
            var result = _rentalDal.GetAll(r => r.CarId == carId).Any();
            if (result)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult CheckCarAvaible(int carId)
        {
            IResult result = BusinessRules.Run(CheckIfCarAvaibleForRent(carId));
            if(result!=null)
            {
                return new ErrorResult("Araç belirtilen tarihte müsait değil.");
            }
            return new SuccessResult("Araç belirtilen tarihte müsait.");
        }
    }
}
