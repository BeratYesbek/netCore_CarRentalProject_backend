using Core.Abstract;
using Core.Utilities.Result.Abstract;
using Entities;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICategoryService : IServiceRepository<Category>
    {
        IDataResult<Category> GetById(int productId);

    }
}
