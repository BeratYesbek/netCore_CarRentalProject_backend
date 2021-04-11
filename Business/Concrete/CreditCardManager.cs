using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Validation.FluentValidation;
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
    public class CreditCardManager : ICreditCardService
    {
        private ICreditCardDal _creditCardDal;
        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }
        //  [LogAspect(typeof(FileLogger))]
        [ValidationAspect(typeof(CartItemValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(CreditCard entity)
        {
           return _creditCardDal.Add(entity);
        }
        //  [LogAspect(typeof(FileLogger))]
        [ValidationAspect(typeof(CartItemValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(CreditCard entity)
        {
            return _creditCardDal.Delete(entity);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<CreditCard> Get(Expression<Func<CreditCard, bool>> filter)
        {
            return _creditCardDal.Get(filter);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CreditCard>> GetAll(Expression<Func<CreditCard, bool>> filter = null)
        {
            return _creditCardDal.GetAll();
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CreditCard>> GetCardByUserId(int userId)
        {
            return _creditCardDal.GetAll(c => c.UserId == userId);
        }

        //  [LogAspect(typeof(FileLogger))]
        [ValidationAspect(typeof(CartItemValidator))]
        [CacheRemoveAspect("ICreditCardService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(CreditCard entity)
        {
            return _creditCardDal.Update(entity);
        }
    }
}
