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
    public class CartItemManager : ICartItemService
    {
        private ICartItemDal _cartItemDal;
        public CartItemManager(ICartItemDal cartItemDal)
        {
            _cartItemDal = cartItemDal;
        }

        //[LogAspect(typeof(FileLogger))]
        [ValidationAspect(typeof(CartItemValidator))]
        [CacheRemoveAspect("ICartItemService.Get")]
        public IResult Add(CartItem entity)
        {
            return _cartItemDal.Add(entity);
        }
        //[LogAspect(typeof(FileLogger))]
        [ValidationAspect(typeof(CartItemValidator))]
        [CacheRemoveAspect("ICartItemService.Get")]
        public IResult Delete(CartItem entity)
        {
            return _cartItemDal.Delete(entity);
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<CartItem> Get(Expression<Func<CartItem, bool>> filter)
        {
            throw new NotImplementedException();
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CartItem>> GetAll(Expression<Func<CartItem, bool>> filter = null)
        {
            return _cartItemDal.GetAll();
        }
        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<CartItem>> GetByUserId(int userId)
        {
            return _cartItemDal.GetAll(c => c.UserId == userId);
        }
        //[LogAspect(typeof(FileLogger))]
        [ValidationAspect(typeof(CartItemValidator))]
        [CacheRemoveAspect("ICartItemService.Get")]
        public IResult Update(CartItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
