using Entities;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;



namespace Business.Validation.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(category => category.CategoryName).NotEmpty();
        }
    }
}
