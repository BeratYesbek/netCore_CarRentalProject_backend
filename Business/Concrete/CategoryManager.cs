using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Validation.FluentValidation;
using Core.Autofac.Caching;
using Core.Autofac.Logging;
using Core.Autofac.Performance;
using Core.Autofac.Validation;
using Core.Constants;
using Core.CrossCuttingConcerns.Logging.Log4Net.DatabaseLogger;
using Core.CrossCuttingConcerns.Transaction;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this._categoryDal = categoryDal;
        }

      //  [LogAspect(typeof(FileLogger))]
        [SecuredOperation("category.add,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        [PerformanceAspect(5)]
        public IResult Add(Category entity)
        {
            return _categoryDal.Add(entity);
        }

        [SecuredOperation("category.delete,admin")]
        [ValidationAspect(typeof(CategoryValidator))]
        [CacheRemoveAspect("ICategoryService.Get")]
        [PerformanceAspect(5)]
        public IResult Delete(Category entity)
        {
            return _categoryDal.Delete(entity);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Category> Get(Expression<Func<Category, bool>> filter)
        {
            return _categoryDal.Get(filter);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Category>> GetAll(Expression<Func<Category, bool>> filter = null)
        {
            return _categoryDal.GetAll(filter);
        }


        [SecuredOperation("category.update,admin")]
        [CacheRemoveAspect("ICategoryService.Get")]
        [PerformanceAspect(5)]
      //  [LogAspect(typeof(FileLogger))]

        public IResult Update(Category entity)
        {
            return _categoryDal.Update(entity);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Category category)
        {
            _categoryDal.Update(category);
            _categoryDal.Add(category);
            return new SuccessResult(Messages.UPDATE_MESSAGE);
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<Category> GetById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }

   
    }
}
