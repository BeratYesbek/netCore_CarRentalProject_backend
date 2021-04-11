using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation.FluentValidation
{
    public class CreditCartValidator : AbstractValidator<CreditCard>
    {
        public CreditCartValidator()
        {
            RuleFor(c => c.CardNumber).NotEmpty().WithMessage("Card Number cannot be empty");
            RuleFor(c => c.CardNumber).MinimumLength(16).WithMessage("card number must be a minimum of 16 characters");
            RuleFor(c => c.CardName).NotEmpty().WithMessage("Card Name cannot be empty");
            RuleFor(c => c.CardYear).NotEmpty().WithMessage("Card Year cannot be empty");
            RuleFor(c => c.Cvv).NotEmpty().WithMessage("Cvv cannot be empty");
            RuleFor(c => c.CardMonth).NotEmpty().WithMessage("Card Month cannot be empty");
            RuleFor(c => c.UserId).NotEmpty().WithMessage("User Id cannot be empty");



        }
    }
}
