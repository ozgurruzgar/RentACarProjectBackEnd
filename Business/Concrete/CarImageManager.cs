using Business.Abstract;
using Business.Contants;
using Core.Utitlities.Business;
using Core.Utitlities.Helpers;
using Core.Utitlities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImagesService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c=>c.CarId==carId));
        }

        public IDataResult<CarImage> GetByImageId(int id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c=>c.Id==id));
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckIfImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.Date = DateTime.Now;
            string oldPath = GetByImageId(carImage.Id).Data.ImagePath;
            carImage.ImagePath = FileHelper.Update(oldPath, file);
            return new SuccessResult();
        }
        private IResult CheckIfImageLimitExceeded(int carId)
        {
            var carImageCount = _carImageDal.GetAll(c=>c.CarId == carId).Count;
            if(carImageCount >=15)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        
        private List<CarImage> CheckIfCarImageNull(int carId)
        {
            string path = @"DefaultImage.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = carId, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == carId);
        }

        private IResult CarImageDelete(CarImage carImage)
        {
            try
            {
                File.Delete(carImage.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
}
