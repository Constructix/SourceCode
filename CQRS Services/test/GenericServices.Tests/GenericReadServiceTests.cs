using System;
using System.Linq;
using GenericServices.Services.Models;
using Xunit;

namespace GenericServices.Tests
{
    public class GenericReadServiceTests
    {
        [Fact]
        public void CustomerReadServiceInstanceCreated()
        {
            GenericReadService<Customer,int> customerReadService = new GenericReadService<Customer, int>(Helpers.Customers.CreateCustomers().ToList());
            Customer expectedCustomer = new Customer(1, "Richard", "Jones");
            Customer actualCustomer = customerReadService.Get(1) as Customer;
            Assert.Equal(expectedCustomer.Id, actualCustomer.Id);
            Assert.Equal(expectedCustomer.FirstName, actualCustomer.FirstName);
            Assert.Equal(expectedCustomer.LastName, actualCustomer.LastName);
        }

        [Fact]
        public void OrdersReadServiceInstanceCreated()
        {
            Guid newGuid = Guid.NewGuid();
            Customer customer = new Customer(1, "Richard","Jones");

            GenericReadService<Order, Guid> orderReadService = new GenericReadService<Order, Guid>(Helpers.Orders.CreateOrders(newGuid, customer).ToList());
            Order expectedOrder = new Order(newGuid, DateTime.Today, customer);
            Order actualOrder = orderReadService.Get(newGuid) as Order;

            Assert.True(expectedOrder.Id.CompareTo(actualOrder.Id) == 0);
            Assert.Equal(expectedOrder.Customer.FirstName, actualOrder.Customer.FirstName);
            Assert.Equal(expectedOrder.Customer.LastName, actualOrder.Customer.LastName);
        }
    }
}