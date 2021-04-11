using Business.Abstract;
using Core.Utilities.Result.Concrete;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Constants;

namespace Business.CustomBusinessRules
{
    public class CustomCarRules
    {

        

        public static Result CheckCategoryId(ICategoryService categoryService, int id)
        {
            var result = categoryService.GetAll(c => c.CategoryId == id);

            if (!result.Success)
            {
                return new ErrorResult(Messages.CATEGORY_NOT_EXISTS);
            }
            return new SuccessResult();
        }

    }
}
