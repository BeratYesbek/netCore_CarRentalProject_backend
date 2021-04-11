using Core.EntityRepository;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Linq;
namespace DataAccess.Concrete
{
    public class EfCarDal : EfEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails(Expression<Func<CarDetailsDto, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from car in context.Cars
                             join color in context.Colors on car.ColorId equals color.ColorId
                             join brand in context.Brands on car.BrandId equals brand.BrandId
                             join category in context.Categories on car.CategoryId equals category.CategoryId

                             // join carImage in context.CarImages on car.CarId equals carImage.CarId
                             select new CarDetailsDto()
                             {
                                 CarId = car.CarId,
                                 CarImages = (from i in context.CarImages where i.CarId == car.CarId select i).ToList(),
                                 Rentals = (from i in context.Rentals where i.CarId == car.CarId select i).ToList(),

                                 //  (from i in context.CarImages where i.CarId == car.CarId select i.ImagePath).ToList(),
                                 Description = car.Description,
                                 BrandId = brand.BrandId,
                                 BrandName = brand.BrandName,
                                 ColorId = color.ColorId,
                                 ColorName = color.ColorName,
                                 ModelName = car.ModelName,
                                 DailyPrice = car.DailyPrice,
                                 ModelYear = car.ModelYear,
                                 FindeksScore = car.FindeksScore,
                                 CategoryName = category.CategoryName,
                                 CategoryId = category.CategoryId,

                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        public List<CarDetailsDto> GetCarsDetail(Expression<Func<Car, bool>> filter = null)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from p in filter == null ? context.Cars : context.Cars.Where(filter)
                             join color in context.Colors on p.ColorId equals color.ColorId
                             join brand in context.Brands on p.BrandId equals brand.BrandId
                             join category in context.Categories on p.CategoryId equals category.CategoryId
                             select new CarDetailsDto
                             {
                                 CarId = p.CarId,
                                 CarImages = (from i in context.CarImages where i.CarId == p.CarId select i).ToList(),
                                 // (context.CarImages).ToList(),
                                 //     (from i in context.CarImages where i.CarId == p.CarId select i.ImagePath).ToList(),
                                 Rentals = (from i in context.Rentals where i.CarId == p.CarId select i).ToList(),
                                 Description = p.Description,
                                 BrandId = brand.BrandId,
                                 BrandName = brand.BrandName,
                                 ColorId = color.ColorId,
                                 ColorName = color.ColorName,
                                 ModelName = p.ModelName,
                                 DailyPrice = p.DailyPrice,
                                 ModelYear = p.ModelYear,
                                 FindeksScore = p.FindeksScore,
                                 CategoryName = category.CategoryName,
                                 CategoryId = category.CategoryId,
                             };
                return result.ToList();
            }
        }
    }
}
