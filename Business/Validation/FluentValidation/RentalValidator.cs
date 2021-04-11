using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class RentalValidator : AbstractValidator<Rental>
    {
        public RentalValidator()
        {
            RuleFor(r => r.RentDate).NotEmpty().WithMessage("Rent date cannot be empty");
            RuleFor(r => r.ReturnDate).NotEmpty().WithMessage("Return date cannot be empty");
            RuleFor(r => r.CarId).NotEmpty().WithMessage("Car Id cannot be empty");
            RuleFor(r => r.CustomerId).NotEmpty().WithMessage("Customer Id cannot be empty");
            RuleFor(r => r.UserId).NotEmpty().WithMessage("User Id cannot be empty");


        }
    }
}
