using Business.Abstract;
using Business.Validation.FluentValidation;
using Core.Autofac.Validation;
using Core.CrossCuttingConcerns;
using Core.Utilities.Result.Abstract;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using FluentValidation;
using Core.Utilities.Business;
using Business.CustomBusinessRules;
using Business.BusinessAspects.Autofac;
using Core.Autofac.Caching;
using Core.Autofac.Performance;
using Core.CrossCuttingConcerns.Transaction;
using Core.Utilities.Result.Concrete;
using Core.Autofac.Logging;
using Core.CrossCuttingConcerns.Logging.Log4Net.DatabaseLogger;
using Core.Constants;
using Business.ValidationRules.FluentValidation;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        private ICarDal _carDal;
        private ICategoryService _categoryService;

        public CarManager(ICarDal cardal, ICategoryService categoryService)
        {
            _carDal = cardal;
            _categoryService = categoryService;
        }

        [LogAspect(typeof(FileLogger))]
        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(Car entity)
        {

            IResult result = BusinessRules.run(
                    CustomCarRules.CheckCategoryId(_categoryService, entity.CategoryId)
                  );
            if (result == null)
            {

                var data = _carDal.Add(entity);
                return data;
            }

            return result;
        }

        [SecuredOperation("car.delete,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(Car entity)
        {

            return _carDal.Delete(entity);


        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Car> Get(Expression<Func<Car, bool>> filter)
        {
            return _carDal.Get(filter);
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            return _carDal.GetAll(filter);

        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetById(int id)
        {
            return _carDal.GetAll(c => c.CarId == id);
        }

        //[LogAspect(typeof(FileLogger))]
         [SecuredOperation("car.update,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult Update(Car entity)
        {
            return _carDal.Update(entity);

        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Car car)
        {
            _carDal.Update(car);
            _carDal.Add(car);
            return new SuccessResult(Messages.UPDATE_MESSAGE);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetByBrand(int brandId)
        {

            return _carDal.GetAll(c => c.BrandId == brandId);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetByCategory(int categoryId)
        {
            return _carDal.GetAll(c => c.CategoryId == categoryId);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetByColor(int colorId)
        {
            return _carDal.GetAll(c => c.ColorId == colorId);
        }

        [CacheAspect]
        [PerformanceAspect(5)]

        public IDataResult<List<CarDetailsDto>> GetCarDetail(int carId)
        {
            if (DateTime.Now.Hour == 5)
            {
                return new ErrorDataResult<List<CarDetailsDto>>("Messages.MaintenanceTime");
            }
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(cardetail => cardetail.CarId == carId));
        }
      
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(), "");
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CarDetailsDto>> GetCarsDetailByColorId(int colorId)
        {
            List<CarDetailsDto> carDetails = _carDal.GetCarDetails(p => p.ColorId == colorId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailsDto>>("");
            }
            else
            {
                return new SuccessDataResult<List<CarDetailsDto>>(carDetails, "");
            }
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CarDetailsDto>> GetCarsDetailByBrandId(int brandId)
        {
            List<CarDetailsDto> carDetails = _carDal.GetCarDetails(p => p.BrandId == brandId);
            if (carDetails == null)
            {
                return new ErrorDataResult<List<CarDetailsDto>>("");
            }
            else
            {
                return new SuccessDataResult<List<CarDetailsDto>>(carDetails, "");
            }
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CarDetailsDto>> GetCarsDetailByCategoryId(int categoryId)
        {
            var result = _carDal.GetCarDetails(p => p.CategoryId == categoryId);
            if(result.Count > 0)
            {
                return new SuccessDataResult<List<CarDetailsDto>>(result);
            }
            return new ErrorDataResult<List<CarDetailsDto>>();
        }


    }
}
