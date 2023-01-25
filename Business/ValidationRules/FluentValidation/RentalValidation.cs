using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
   public class RentalValidation:AbstractValidator<Rental>
    {
        public RentalValidation()
        {
            RuleFor(r => r.RentalId).NotEmpty();
            RuleFor(r => r.RentalId).GreaterThan(2);
            RuleFor(r=>r.CarId).NotEmpty();
            RuleFor(r=>r.CarId).GreaterThan(2);
            RuleFor(r=>r.CustomerId).NotEmpty();
            RuleFor(r=>r.CustomerId).GreaterThan(2);
            RuleFor(r => r.RentDate).Empty().When(r => r.ReturnDate == null);
        }
    }
}
