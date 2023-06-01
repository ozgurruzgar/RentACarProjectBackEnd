using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidation:AbstractValidator<Car>
    {
        public CarValidation()
        {
            RuleFor(c => c.BrandId).GreaterThan(0);
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.ColorId).GreaterThan(0);
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.Model).NotEmpty();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.ModelYear).NotEmpty();
            RuleFor(c => c.ModelYear).GreaterThan((short)0);
            RuleFor(c => c.Model).MinimumLength(3);
            RuleFor(c => c.DailyPrice).GreaterThan((short)0);
            RuleFor(c => c.Description).MinimumLength(3);
        }
    }
}
