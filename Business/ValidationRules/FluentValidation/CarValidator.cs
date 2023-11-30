using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(c=>c.BrandId).NotEmpty();
            RuleFor(c=>c.Name).MinimumLength(2);
            RuleFor(c=>c.DailyPrice).NotEmpty();
            RuleFor(c=>c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.ModelYear).Must(FourChar).WithMessage("Model yılı dört haneli olmalıdır");
        }

        private bool FourChar(int modelYear)
        {
            return modelYear >= 1000 && modelYear <= 9999;
        }
    }
}
