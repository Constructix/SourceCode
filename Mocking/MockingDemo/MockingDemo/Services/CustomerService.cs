namespace MockingDemo
{

    
    public class CustomerService
    {
        private IFactory<Customer, ICustomerFactoryInputData> _factory;
        private IRepository<Customer> _repository;


        public CustomerService(IFactory<Customer, ICustomerFactoryInputData> factory, 
            IRepository<Customer> repository)
        {
            _factory = factory;
            _repository = repository;
        }

        public void Create(CustomerInputData data)
        {
            var customer = _factory.Create(data);
            if (customer != null)
            {
                _repository.Add(customer);
            }
        }


    }
}