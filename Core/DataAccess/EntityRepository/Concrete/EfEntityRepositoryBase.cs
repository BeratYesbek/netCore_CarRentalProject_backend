using Core.Abstract;
using Core.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.EntityRepository
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public IResult Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

                return new SuccessResult(Messages.ADD_MESSAGE);
            }
            return new ErrorResult(Messages.ERROR_MESSAGE);
        }

        public IResult Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();

                return new SuccessResult(Messages.DELETE_MESSAGE);
            }
            return new ErrorResult(Messages.ERROR_MESSAGE);

        }

        public IDataResult<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {

                var result =  context.Set<TEntity>().SingleOrDefault(filter);
                if(result != null)
                {
                    return new SuccessDataResult<TEntity>(result);
                }
            }
            return new ErrorDataResult<TEntity>();

        }

        public IDataResult<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                var result = filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

                if (result.Count > 0)
                {
                    return new SuccessDataResult<List<TEntity>>(result,"Success");

                }
                return new ErrorDataResult<List<TEntity>>(Messages.ERROR_MESSAGE);
            }

        }

        public IResult Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
                return new SuccessResult(Messages.UPDATE_MESSAGE);
            }
            return new ErrorResult(Messages.ERROR_MESSAGE);

        }
       
   
    }
}
