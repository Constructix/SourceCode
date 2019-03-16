using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public List<OrderItem>  OrderItems { get;  }

        public Order()
        {
            OrderItems = new List<OrderItem>();


        }

        public Order(Guid id, List<OrderItem> orderItems)
        {
            Id = id;
            OrderItems = orderItems;
        }

    }
}