using System;

namespace OrderServices.Tests
{
    internal class Order
    {
        public Guid Id { get; internal set; }
        public OrderStatus Status {get;set;}

        public DateTime? CancelledOn { get; set; }

        public Order()
        {
            Status = OrderStatus.Created;
            Id = Guid.NewGuid();
        }

        
    }
}
