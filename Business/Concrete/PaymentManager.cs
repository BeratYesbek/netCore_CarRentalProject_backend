using Business.Abstract;
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
    public class PaymentManager : IPaymentService
    {
        private IPaymentDal _paymentDal;
        public PaymentManager(IPaymentDal paymentDal)
        {
            _paymentDal = paymentDal;
        }

        [ValidationAspect(typeof(PaymentValidator))]
        [CacheRemoveAspect("IPaymentService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(Payment entity)
        {
            return _paymentDal.Add(entity);
        }

        [ValidationAspect(typeof(PaymentValidator))]
        [CacheRemoveAspect("IPaymentService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(Payment entity)
        {
            throw new NotImplementedException();
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Payment> Get(Expression<Func<Payment, bool>> filter)
        {
            throw new NotImplementedException();
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Payment>> GetAll(Expression<Func<Payment, bool>> filter = null)
        {
            return _paymentDal.GetAll();
        }


        [ValidationAspect(typeof(PaymentValidator))]
        [CacheRemoveAspect("IPaymentService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(Payment entity)
        {
            throw new NotImplementedException();
        }
    }
}
