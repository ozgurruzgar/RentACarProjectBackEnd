using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidation:AbstractValidator<Color>
    {
        public ColorValidation()
        {
            RuleFor(c=>c.ColorName).NotEmpty();
            RuleFor(c=>c.ColorName).MinimumLength(2);
        }
    }
}
