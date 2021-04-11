using Business.Abstract;
using Business.CustomBusinessRules;
using Business.ValidationRules.FluentValidation;
using Core.Autofac.Caching;
using Core.Autofac.Performance;
using Core.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        private IRentalDal _rentalDal;
        private ICustomerService _customerService;
        private ICarService _carService;

        public RentalManager(IRentalDal rentalDal, ICustomerService customerService, ICarService carService)
        {
            _rentalDal = rentalDal;
            _customerService = customerService;
            _carService = carService;
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(Rental entity)
        {
            var result = BusinessRules.run(
                    CustomRentalRules.CheckFindeksScore(_customerService,_carService, entity.CarId, entity.UserId)
                );
            if (result == null)
            {
                return _rentalDal.Add(entity);
            }
            return result;
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(Rental entity)
        {
            return _rentalDal.Delete(entity);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Rental> Get(Expression<Func<Rental, bool>> filter)
        {
            return _rentalDal.Get(filter);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Rental>> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            return _rentalDal.GetAll();
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<RentalDetailDto>> GetAllRentalDetails()
        {
            var result = _rentalDal.GetAllRentalDetails();
            return new SuccessDataResult<List<RentalDetailDto>>(result);
        }

        [ValidationAspect(typeof(RentalValidator))]
        [CacheRemoveAspect("IRentalService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(Rental entity)
        {
            return _rentalDal.Update(entity);
        }
    }
}
