using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.ValidationRules.FluentValidation;
using Core.Autofac.Caching;
using Core.Autofac.Logging;
using Core.Autofac.Performance;
using Core.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.DatabaseLogger;
using Core.Utilities.Result.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class AdminManager : IAdminService
    {
        private IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }


     //   [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IAdminService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(Admin entity)
        {
            return _adminDal.Add(entity);
        }


     //   [LogAspect(typeof(FileLogger))]
        [SecuredOperation("admin.delete,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("IAdminService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(Admin entity)
        {
            return _adminDal.Delete(entity);
        }

        [CacheAspect]
        [SecuredOperation("admin.get,admin")]
        [PerformanceAspect(5)]
        public IDataResult<Admin> Get(Expression<Func<Admin, bool>> filter)
        {
            return _adminDal.Get(filter);
        }
        [CacheAspect]
        [SecuredOperation("admin.get,admin")]
        [PerformanceAspect(5)]
        public IDataResult<List<Admin>> GetAll(Expression<Func<Admin, bool>> filter = null)
        {
            return _adminDal.GetAll();
        }
        [CacheAspect]
        //[SecuredOperation("admin.get,admin")]
        [PerformanceAspect(5)]
        public IDataResult<Admin> GetByUserId(int userId)
        {
            return _adminDal.Get(a => a.UserId == userId);
        }
        [CacheRemoveAspect("IAdminService.Get")]
        [SecuredOperation("admin.update,admin")]
        [PerformanceAspect(5)]
        public IResult Update(Admin entity)
        {
            return _adminDal.Update(entity);
        }
    }
}
