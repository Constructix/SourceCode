namespace MockingDemo
{
    public class OrderService
    {
        private IFactory<Order, IOrderFactoryInputData> _factory;
        private IRepository<Order> _repository;

        public OrderService(IFactory<Order, IOrderFactoryInputData> factory, IRepository<Order> repository)
        {
            _factory = factory;
            _repository = repository;
        }

        public void Create(IOrderFactoryInputData data)
        {
            var order = _factory.Create(data);
            if (order != null)
            {
                _repository.Add(order);
                
               
            }
        }
    }
}