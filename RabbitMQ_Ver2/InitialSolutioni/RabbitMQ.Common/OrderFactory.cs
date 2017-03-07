using System;

namespace RabbitMQ.Common
{
    public class OrderFactory
    {
        public Order  Create(Customer customer)
        {
            return new Order() {Customer = customer, Created = DateTime.Now, LastModified = DateTime.Now};
        }
    }
}