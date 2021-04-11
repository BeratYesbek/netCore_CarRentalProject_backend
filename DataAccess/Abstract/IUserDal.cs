using Core.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        List<UserDetailsDto> GetUserDetailsById(Expression<Func<User, bool>> filter = null);
    }
}
