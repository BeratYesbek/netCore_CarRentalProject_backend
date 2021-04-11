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
    public class ApplicantionManager : IApplicantionService
    {
        private IApplicantDal _customerApplicantDal;
        public ApplicantionManager(IApplicantDal customerApplicantDal)
        {
            _customerApplicantDal = customerApplicantDal;
        }

        //   [LogAspect(typeof(FileLogger))]
        [ValidationAspect(typeof(ApplicantValidator))]
        [CacheRemoveAspect("IApplicantionService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(Applicant entity)
        {
            return _customerApplicantDal.Add(entity);
        }

        // [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IApplicantionService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(Applicant entity)
        {
            return _customerApplicantDal.Delete(entity);
        }


        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Applicant> Get(Expression<Func<Applicant, bool>> filter)
        {
            return _customerApplicantDal.Get(filter);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Applicant>> GetAll(Expression<Func<Applicant, bool>> filter = null)
        {
            return _customerApplicantDal.GetAll();
        }

        // [LogAspect(typeof(FileLogger))]
        [CacheRemoveAspect("IApplicantionService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(Applicant entity)
        {
            return _customerApplicantDal.Update(entity);
        }
    }
}
