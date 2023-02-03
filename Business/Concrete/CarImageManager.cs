using Business.Abstract;
using Business.Contants;
using Core.Utitlities.Business;
using Core.Utitlities.Helper.FileHelper;
using Core.Utitlities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelper _fileHelper;
        public CarImageManager(ICarImageDal carImageDal,IFileHelper fileHelper)
        {
            _carImageDal  = carImageDal;
            _fileHelper = fileHelper;
        }

        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckCarImage(carImage.CarId),CheckCarImageRange(carImage.CarId));
            if(result != null)
            {
                return result;
            }
            carImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesPath);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult("Resim Başarıyla Yüklendi.");
        }

        public IResult Delete(CarImage carImage)
        {
            _fileHelper.Delete(PathConstants.ImagesPath + carImage.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult("Resim Başarıyla Silindi.");
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = BusinessRules.Run(CheckCarImage(carId));
            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(GetDefaultImage(carId).Data.ToString());
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId));
        }

        public IDataResult<CarImage> GetByImageId(int imageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(c => c.Id == imageId));
        }

        public IResult Update(IFormFile file, CarImage carImage)
        {
            _fileHelper.Update(file, PathConstants.ImagesPath + carImage.ImagePath,PathConstants.ImagesPath);
            _carImageDal.Update(carImage);
            return new SuccessResult("Resim Başarıyla Güncellendi.");
        }

        private IResult CheckCarImage(int carId)
        {
            var result = _carImageDal.GetAll(c=>c.CarId ==carId).Count;
            if(result>0)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        private IResult CheckCarImageRange(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Count;
            if (result >= 5)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
        private IDataResult<List<CarImage>> GetDefaultImage(int carId)
        {
            List<CarImage> carImage = new List<CarImage>();
            carImage.Add( new CarImage { CarId = carId, Date = DateTime.Now, ImagePath = ""});
            return new SuccessDataResult<List<CarImage>>(carImage);
        }
    }
}
