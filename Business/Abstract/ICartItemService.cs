using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICartItemService : IServiceRepository<CartItem>
    {
        IDataResult<List<CartItem>> GetByUserId(int userId);
    }
}
