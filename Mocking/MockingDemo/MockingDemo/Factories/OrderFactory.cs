namespace MockingDemo
{
    public class OrderFactory : IFactory<Order, IOrderFactoryInputData>
    {
        public Order Create(IOrderFactoryInputData inputData)
        {
            return new Order() { Created = inputData.Created, Customer = inputData.Customer };
        }
    }
}