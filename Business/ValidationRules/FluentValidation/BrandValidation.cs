using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class BrandValidation:AbstractValidator<Brand>
    {
        public BrandValidation()
        {
            RuleFor(c => c.BrandId).NotEmpty();
            RuleFor(c => c.BrandId).GreaterThan(0);
            RuleFor(c => c.BrandName).NotEmpty();
            RuleFor(c => c.BrandName).MinimumLength(2);
        }
    }
}
