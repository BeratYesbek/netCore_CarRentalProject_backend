using Core.EntityRepository;
using DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfUserImageDal : EfEntityRepositoryBase<UserImage,NorthwindContext> , IUserImageDal
    {
    }
}
