using System;
using System.Collections.Generic;

namespace Orders.API
{
    public class Order  
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }

        public List<OrderItem> OrderItems { get; set; }

        public Order(int id, DateTime created)
        {
            Id = id;
            Created = created;
        }
    }

    public class OrderItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

        public OrderItem(string name, int quantity)
        {
            Name = name;
            Quantity = quantity;
        }
    }

    public class CreateOrderRequest
    {
        public List<OrderItem> OrderItems { get; set; }

        public CreateOrderRequest(List<OrderItem> orderItems)
        {
            OrderItems = orderItems;
        }
    }

    public class CreateOrderResponse
    {
        public Order Order { get; set; }


        public CreateOrderResponse(Order order)
        {
            Order = order;
        }
    }
}
