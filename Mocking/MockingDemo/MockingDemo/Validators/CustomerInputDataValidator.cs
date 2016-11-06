using FluentValidation;

namespace MockingDemo
{
    public class CustomerInputDataValidator : AbstractValidator<ICustomerFactoryInputData>
    {
        public CustomerInputDataValidator()
        {
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}