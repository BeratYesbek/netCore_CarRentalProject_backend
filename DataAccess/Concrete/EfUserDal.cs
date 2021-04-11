using Core.Abstract;
using Core.Entities.Concrete;
using Core.EntityRepository;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.Dtos;
using System.Linq.Expressions;
using Core.Utilities.Result.Abstract;
using Microsoft.EntityFrameworkCore;
using Core.Utilities.Result.Concrete;
using Core.Constants;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public List<UserDetailsDto> GetUserDetailsById(Expression<Func<User, bool>> filter = null)
        {

            using (NorthwindContext context = new NorthwindContext())
            {

                var result = from user in filter == null ? context.Users : context.Users.Where(filter)
                             select new UserDetailsDto()
                             {

                                 Images = (from i in context.UserImages where i.UserId == user.Id select i).ToList(),
                                 FindeksScore = (from i in context.Customers where i.UserId == user.Id select i.FindeksScore).ToList(),
                                 FirstName = user.FirstName,
                                 LastName = user.LastName,
                                 Email = user.Email,
                                 PasswordHash = user.PasswordHash,
                                 PasswordSalt = user.PasswordSalt,
                                 Status = user.Status,
                                 Id = user.Id,
                                 AdminId = (from i in context.Admins where i.UserId == user.Id select i.AdminId).ToList(),
                                 CustomerId = (from i in context.Customers where i.UserId == user.Id select i.CustomerId).ToList(),

                             };
                return result.ToList();


            }

        }
    }
}
