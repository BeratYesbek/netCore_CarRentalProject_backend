using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Validation.FluentValidation
{
    class UserImageValidator : AbstractValidator<UserImage>
    {
        public UserImageValidator()
        {
            RuleFor(u => u.ImagePath).NotEmpty();
            RuleFor(u => u.UserId).NotEmpty();

        }
    }
}
