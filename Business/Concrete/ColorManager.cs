using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Validation.FluentValidation;
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
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }


        //  [LogAspect(typeof(FileLogger))]
        [SecuredOperation("color.add,admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(Color entity)
        {
          return  _colorDal.Add(entity);
        }

        //  [LogAspect(typeof(FileLogger))]
        [SecuredOperation("color.delete,admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(Color entity)
        {
            return _colorDal.Delete(entity);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Color> Get(Expression<Func<Color, bool>> filter)
        {
            throw new NotImplementedException();
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Color>> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            return _colorDal.GetAll(filter);
        }


        //  [LogAspect(typeof(FileLogger))]
        [SecuredOperation("color.update,admin")]
        [ValidationAspect(typeof(ColorValidator))]
        [CacheRemoveAspect("IColorService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(Color entity)
        {
          return  _colorDal.Update(entity);
        }
    }
}
