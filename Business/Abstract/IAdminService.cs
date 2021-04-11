using Core.Utilities.Result.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAdminService  : IServiceRepository<Admin>
    {
        IDataResult<Admin> GetByUserId(int userId);
    }
}
