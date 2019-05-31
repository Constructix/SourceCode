using System;
using System.Collections.Generic;

namespace OrderServices.Domain
{
    public class Order
    {
        public Guid Id { get; internal set; }
        public OrderStatus Status {get;set;}
        public DateTime Created { get; set; }

        public DateTime? CancelledOn { get; set; }

        public List<OrderHistory> History { get; set; }

        public Order()
        {
            Status = OrderStatus.Created;
            Created = DateTime.Now;
            Id = Guid.NewGuid();
            History =  new List<OrderHistory>{ new OrderHistory { Event = Status, Created = Created, Notes =  string.Empty}};


        }
    }
}
