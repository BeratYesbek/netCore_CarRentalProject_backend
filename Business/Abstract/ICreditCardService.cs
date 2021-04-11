using Core.Abstract;
using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICreditCardService : IEntityRepository<CreditCard>
    {
        IDataResult<List<CreditCard>> GetCardByUserId(int userId);
    }
}
