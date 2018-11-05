using System;
using System.Collections.Generic;
using GenericServices.Services.Models;

namespace GenericServices.Tests
{
    public static class Helpers
    {
        public static class Customers
        {
            public static IList<Customer> CreateCustomers()
            {
                return new List<Customer> { new Customer(1, "Richard", "Jones"), new Customer(2, "John", "Williams") };
            }
        }
        public static class Orders
        {
            public static List<Order> CreateOrders(Guid newGuid, Customer customer)
            {
                return new List<Order> {  new Order( newGuid, DateTime.Today, customer) };
            }
        }
    }
}