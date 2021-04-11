using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation.FluentValidation
{
    public class PaymentValidator : AbstractValidator<Payment>
    {
        public PaymentValidator()
        {
            RuleFor(p => p.Address).NotEmpty().WithMessage("Address cannot be empty");
            RuleFor(p => p.CardMonth).NotEmpty().WithMessage("Card Month cannot be empty");
            RuleFor(p => p.CardName).NotEmpty().WithMessage("Card Name cannot be empty");
            RuleFor(p => p.CardYear).NotEmpty().WithMessage("Card Year cannot be empty");
            RuleFor(p => p.Cvv).NotEmpty().WithMessage("Cvv cannot be empty");
            RuleFor(p => p.FullName).NotEmpty().WithMessage("Full name cannot be empty");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email cannot be empty");
            RuleFor(p => p.Zip).NotEmpty().WithMessage("Zip cannot be empty");
            RuleFor(p => p.State).NotEmpty().WithMessage("State cannot be empty");




        }
    }
}
