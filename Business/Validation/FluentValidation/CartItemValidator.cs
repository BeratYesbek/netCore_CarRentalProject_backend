using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation.FluentValidation
{
    public class CartItemValidator : AbstractValidator<CartItem>
    {
        public CartItemValidator()
        {
            RuleFor(c => c.UserId).NotEmpty().WithMessage("User Id cannot be empty");
            RuleFor(c => c.CarId).NotEmpty().WithMessage("Car Id cannot be empty");
        }
    }
}
