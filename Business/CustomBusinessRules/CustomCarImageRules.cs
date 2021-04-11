using Core.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CustomBusinessRules
{
    public class CustomCarImageRules
    {

        public static IResult CheckImageCount(ICarImageDal carImageDal,int carId)
        {
            var result = carImageDal.GetAll(c => c.CarId == carId);

            if (result.Data.Count >= 5)
            {
                return new ErrorResult(Messages.CAR_IMAGE_COUNT_ERROR);
            }
            return new SuccessResult();
        }
    }
}
