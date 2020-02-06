using System;

namespace EventDemo
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? Deleted { get; set; }
    }
}