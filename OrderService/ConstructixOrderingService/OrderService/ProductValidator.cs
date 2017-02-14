using FluentValidation;

namespace Project1
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
        }
    }
}