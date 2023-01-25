using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CustomerValidation:AbstractValidator<Customer>
    {
        public CustomerValidation()
        {
            RuleFor(c => c.UserId).NotEmpty();
            RuleFor(c => c.UserId).GreaterThan(0);
            RuleFor(c => c.CompanyName).NotEmpty();
            RuleFor(c => c.CompanyName).MinimumLength(2);
        }
    }
}
