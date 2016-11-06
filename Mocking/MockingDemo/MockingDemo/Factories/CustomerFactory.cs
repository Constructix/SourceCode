namespace MockingDemo
{
    public class CustomerFactory : IFactory<Customer, ICustomerFactoryInputData>

    {
        public Customer Create(ICustomerFactoryInputData inputData)
        {
            var customerValidator = new CustomerInputDataValidator();
            var response = customerValidator.Validate(inputData);
            if (response.IsValid)
            {
                return new Customer()
                {
                    FirstName = inputData.FirstName,
                    LastName = inputData.LastName,
                    Email = inputData.Email
                };
            }
            return null;
        }
    }
}