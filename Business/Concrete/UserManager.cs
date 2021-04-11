using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Autofac.Caching;
using Core.Autofac.Performance;
using Core.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(User user)
        {
            return _userDal.Add(user);
        }

        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(User entity)
        {
            return _userDal.Delete(entity);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<User> Get(Expression<Func<User, bool>> filter)
        {
            return _userDal.Get(filter);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<User>> GetAll(Expression<Func<User, bool>> filter = null)
        {
            return _userDal.GetAll(filter);
        }

       // [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<UserDetailsDto>> GetById(int userId)
        {
            var result = _userDal.GetUserDetailsById(user => user.Id == userId);
            return new SuccessDataResult<List<UserDetailsDto>>(result);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<User> GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);

        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);

        }

        [ValidationAspect(typeof(UserValidator))]
        [CacheRemoveAspect("IUserService.Get")]
        [PerformanceAspect(5)]
        public IResult Update(User entity)
        {
            return _userDal.Update(entity);
        }
    }
}
