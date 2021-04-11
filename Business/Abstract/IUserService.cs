using Core.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        IDataResult<User> GetByMail(string email);
        IDataResult<List<Entities.Dtos.UserDetailsDto>> GetById(int userId);
    }
}
