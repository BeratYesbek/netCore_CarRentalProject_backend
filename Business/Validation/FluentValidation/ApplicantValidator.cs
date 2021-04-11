using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation.FluentValidation
{
    public class ApplicantValidator : AbstractValidator<Applicant>
    {
        public ApplicantValidator()
        {
            RuleFor(a => a.CompanyName).NotEmpty().WithMessage("Company name cannot be empty");
            RuleFor(a => a.CompanyName).MinimumLength(2).WithMessage("Company name must be at least 2 characters");
            RuleFor(a => a.UserId).NotEmpty().WithMessage("User Id cannot be empty");
        }
    }
}
