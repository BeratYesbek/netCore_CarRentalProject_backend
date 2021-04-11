using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Autofac.Caching;
using Core.Autofac.Performance;
using Core.Autofac.Validation;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        //   [LogAspect(typeof(FileLogger))]
        [SecuredOperation("brand.add,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.GetAll")]
        [PerformanceAspect(5)]
        public IResult Add(Brand entity)
        {
            return _brandDal.Add(entity);
        }

        //   [LogAspect(typeof(FileLogger))]
        [SecuredOperation("brand.delete,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(Brand entity)
        {
            return _brandDal.Delete(entity);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Brand> Get(Expression<Func<Brand, bool>> filter)
        {
            return _brandDal.Get(filter);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Brand>> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            return _brandDal.GetAll();
        }

        //   [LogAspect(typeof(FileLogger))]
        [SecuredOperation("brand.update,admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(Brand entity)
        {
            return _brandDal.Update(entity);
        }
    }
}
