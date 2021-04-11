using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Autofac.Caching;
using Core.Autofac.Performance;
using Core.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        //  [LogAspect(typeof(FileLogger))]
        [SecuredOperation("customer.add,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(Customer entity)
        {
            return _customerDal.Add(entity);
        }

        //  [LogAspect(typeof(FileLogger))]
        [SecuredOperation("customer.delete,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(Customer entity)
        {
            return _customerDal.Delete(entity);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Customer> Get(Expression<Func<Customer, bool>> filter)
        {
            return _customerDal.Get(filter);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Customer>> GetAll(Expression<Func<Customer, bool>> filter = null)
        {
            return _customerDal.GetAll(filter);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Customer> GetById(int userId)
        {
           return _customerDal.Get(c => c.UserId == userId);
        }

        //  [LogAspect(typeof(FileLogger))]
        [SecuredOperation("customer.update,admin")]
        [ValidationAspect(typeof(CustomerValidator))]
        [CacheRemoveAspect("ICustomerService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(Customer entity)
        {
            return _customerDal.Update(entity);
        }
    }
}
