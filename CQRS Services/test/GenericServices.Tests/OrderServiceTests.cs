using System;
using System.Collections.Generic;
using GenericServices.Services.Models;
using Xunit;

namespace GenericServices.Tests
{


    public class OrderServiceTests
    {
        [Fact]
        public void OrderServicesCreatedUsingGenericServices()
        {
            var testId = Guid.NewGuid();
            var expectedOrder = new Order(testId, DateTime.Now, new Customer(1, "Richard", "Jones"));
            GenericService<Order, Guid> orderService = new GenericService<Order, Guid>(CreateOrder(testId, 1, "Richard", "Jones"));

            Order actualOrder =  orderService.Get(testId) as Order;

            Assert.Equal(expectedOrder.Id, actualOrder.Id);
            Assert.Equal(expectedOrder.Customer.FirstName, actualOrder.Customer.FirstName);
            Assert.Equal(expectedOrder.Customer.LastName, actualOrder.Customer.LastName);


        }

        private List<IEntity<Guid>> CreateOrder(Guid testGuidId,int testId,  string testFirstName, string testLastName)
        {
            return new List<IEntity<Guid>> { new Order(testGuidId, DateTime.Now, new Customer(testId, testFirstName, testLastName))};
        }
        private List<IEntity<Guid>> CreateOrders()
        {
            return new List<IEntity<Guid>>
            {
                new Order(Guid.NewGuid(), DateTime.Now, new Customer(1, "Richard", "Jones")),
                new Order(Guid.NewGuid(), DateTime.Now, new Customer(2,"William", "Peters")),
                new Order(Guid.NewGuid(), DateTime.Now, new Customer(3,"John", "Williams")),
            };
        }
    }
}