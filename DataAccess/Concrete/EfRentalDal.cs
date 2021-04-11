using Core.EntityRepository;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFrameWork
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, NorthwindContext>, IRentalDal
    {
        public List<RentalDetailDto> GetAllRentalDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from rent in context.Rentals
                             join car in context.Cars on rent.CarId equals car.CarId
                             join brand in context.Brands on car.BrandId equals brand.BrandId

                             join customer in context.Customers on rent.UserId equals customer.UserId

                             join images in context.CarImages on car.CarId equals images.CarId
                             join user in context.Users on customer.UserId equals user.Id

                             select new RentalDetailDto
                             {
                                 Id = rent.Id,
                                 BrandName = brand.BrandName,
                                 CustomerName = user.FirstName + user.LastName,
                                 RentDate = rent.RentDate,
                                 ReturnDate = rent.ReturnDate,
                                 ImagePath = images.ImagePath,
                             };
                return result.ToList();
            }
        }


    }
}
