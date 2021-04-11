using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CustomBusinessRules;
using Business.ValidationRules.FluentValidation;
using Core.Autofac.Caching;
using Core.Autofac.Performance;
using Core.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileManage.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        //[LogAspect(typeof(FileLogger))]
        [SecuredOperation("carImageAdd.add,admin")]
        [CacheRemoveAspect("ICarImageService.Get")]
        [PerformanceAspect(5)]

        public IResult Add(IFormFile file, CarImage carImage)
        {

            var result = BusinessRules.run(CustomCarImageRules.CheckImageCount(_carImageDal, carImage.CarId));
            if(result != null)
            {
                return result;
            }
            var imageResult = FileHelper.Upload(file);

            if (!imageResult.Success)
            {
                return new ErrorResult("");
            }
            carImage.ImagePath = imageResult.Message;
            _carImageDal.Add(carImage);

            return new SuccessResult("Car image added");
        }

        //[LogAspect(typeof(FileLogger))]
        [SecuredOperation("carImageAdd.delete,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(CarImage carImage)
        {
            var result = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (result == null)
            {
                return new ErrorResult("Image not found");
            }

            FileHelper.Delete(result.Data.ImagePath);
            _carImageDal.Delete(carImage);
            return new SuccessResult("Image was deleted successfully");
        }

        //   [LogAspect(typeof(FileLogger))]
        [SecuredOperation("carImageAdd.update,admin")]
        [ValidationAspect(typeof(CarImageValidator))]
        [CacheRemoveAspect("ICarImageService.Get")]
        [PerformanceAspect(5)]

        public IResult Update(IFormFile file, CarImage carImage)
        {


            var updatedFile = FileHelper.Update(file, carImage.ImagePath);
            if (!updatedFile.Success)
            {
                return new ErrorResult(updatedFile.Message);
            }
            carImage.ImagePath = updatedFile.Message;
            _carImageDal.Update(carImage);

            return new SuccessResult("Car image updated");
        }

        [CacheAspect]
        [PerformanceAspect(5)]

        public IDataResult<List<CarImage>> GetAll()
        {
            return _carImageDal.GetAll();
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CarImage>> GetImagesByCarId(int id)
        {
            IResult result = BusinessRules.run(CheckIfCarImageNull(id));

            if (result != null)
            {
                return new ErrorDataResult<List<CarImage>>(result.Message);
            }

            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(id).Data);
        }



        private IDataResult<List<CarImage>> CheckIfCarImageNull(int id)
        {
            try
            {
                string path = @"\images\logo.jpg";
                var result = _carImageDal.GetAll(c => c.CarId == id);
                if (result.Success)
                {
                    List<CarImage> carimage = new List<CarImage>();
                    carimage.Add(new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now });
                    return new SuccessDataResult<List<CarImage>>(carimage);
                }
            }
            catch (Exception exception)
            {

                return new ErrorDataResult<List<CarImage>>(exception.Message);
            }

            return _carImageDal.GetAll(p => p.CarId == id);
        }


    }
}
