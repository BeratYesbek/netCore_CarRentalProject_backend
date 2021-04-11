using Business.Abstract;
using Core.Constants;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.CustomBusinessRules
{
    public class CustomRentalRules
    {
        public static IResult CheckFindeksScore(ICustomerService customerService,ICarService carService,int carId,int userId)
        {   
            var result = customerService.GetById(userId);
            var carResult = carService.Get(c => c.CarId == carId);
            if (result.Success && result.Data.FindeksScore > carResult.Data.FindeksScore)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.RENTAL_FINDEKS_SCORE_NOT_ENOUGH);
        }
    }
}
