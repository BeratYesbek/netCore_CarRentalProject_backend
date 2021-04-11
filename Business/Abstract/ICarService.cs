using Core.Abstract;
using Core.Utilities.Result.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService : IEntityRepository<Car>
    {
        IDataResult<List<Car>> GetById(int productId);
        IDataResult<List<Car>> GetByBrand(int brandId);
        IDataResult<List<Car>> GetByCategory(int categoryId);
        IDataResult<List<Car>> GetByColor(int colorId);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<CarDetailsDto>> GetCarDetail(int carId);
        IDataResult<List<CarDetailsDto>> GetCarsDetailByBrandId(int brandId);
        IDataResult<List<CarDetailsDto>> GetCarsDetailByCategoryId(int categoryId);
        IDataResult<List<CarDetailsDto>> GetCarsDetailByColorId(int colorId);


    }
}
