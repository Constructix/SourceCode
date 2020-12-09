using System;
using System.Collections.Generic;
using Shouldly;
using Xunit;

namespace DomainEvents.tests
{

    public class DomainEventEnvelope<T> where T : IDomainEvent
    {
        
    }

    public class DomainEventEnvelopeTests
    {
        [Fact]
        public void CreateInstance()
        {
            var envelope = new DomainEventEnvelope<OrderCreated>();
            
        }
    }
    public class DomainEventsTests
    {
        [Fact]
        public void CreateOrderEventCreated()
        {
            var orderCreated = new OrderCreated( new Order(), new List<OrderItem>{ new OrderItem()});
            orderCreated.ShouldNotBe(null);
            orderCreated.ShouldBeOfType<OrderCreated>();
        }
    }

    public class Order
    {
        
    }

    public class OrderItem
    {
        public int Quantity { get; set; }
        public Product Product { get; set; }
    }

    public class Product
    {
    }


    public class OrderCreatedCommand
    {
        public Order Order { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        
    }
    public class OrderCreated : IOrderDomainEvent
    {
        public Order Order { get; private set; }
        public List<OrderItem> OrderItems { get; private set; }


        public OrderCreated(Order order, List<OrderItem> orderItems)
        {
            Order = order;
            OrderItems = orderItems;
        }

        public DateTime Created { get; set; }

        public void Process()
        {
            
        }

        public string EventType { get; set; }
    }

    public interface IOrderDomainEvent : IDomainEvent
    {
        public string EventType { get; set; }
        
    }

    public interface IDomainEvent
    {
        public DateTime Created { get; set; }
        
        public void Process();
    }
}
