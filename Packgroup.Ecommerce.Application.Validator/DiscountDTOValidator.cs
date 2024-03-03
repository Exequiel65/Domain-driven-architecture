using FluentValidation;
using Packgroup.Ecommerce.Aplication.DTO;

namespace Packgroup.Ecommerce.Application.Validator
{
    public class DiscountDTOValidator : AbstractValidator<DiscountDto>
    {
        public DiscountDTOValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty();
            RuleFor(x => x.Description).NotNull().NotEmpty();
            RuleFor(x => x.Percent).NotNull().NotEmpty();
            RuleFor(x => x.Percent).NotNull().NotEmpty().GreaterThan(0);
        }
    }
}
