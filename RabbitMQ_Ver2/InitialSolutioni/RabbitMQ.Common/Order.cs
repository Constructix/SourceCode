using System;

namespace RabbitMQ.Common
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }

        public Customer Customer { get; set; }


        public Order()
        {
            Id = Guid.NewGuid();
            Customer = new Customer();
        }

        
    }
}