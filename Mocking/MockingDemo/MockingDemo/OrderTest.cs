using System;
using System.Collections.Generic;
using System.Data.Entity;
using Moq;
using NUnit.Framework;

namespace MockingDemo
{
    [TestFixture]
    public class OrderTest
    {
        [Test]
        public void When_Instance_Created()
        {
            var order = new Order();
            Assert.IsNotNull(order);
        }

       

        [Test]
        public void AddORderWithCustomerDetails()
        {
            var orderFactoryInputData = new OrderFactoryInputData()
            {
                Created = DateTime.Now,
                Customer = new Customer
                {
                    Address = new Address {Suburb = "Karalee", PostCode = "4306", StreetLine1 = "11 Carbine Court"},
                    Email = "r_jones@constructix.com.au",
                    FirstName = "Richard",
                    LastName = "Jones"

                }
            };
            var mockOrders = new Mock<DbSet<Order>>();
            var mockConstructixServicesContext = new Mock<ConstructixServicesContext>();
            mockConstructixServicesContext.Setup(x => x.Orders.Add(It.IsAny<Order>()));
            
            var orderFactory = new OrderFactory();
            var orderRepository = new OrderRepository(mockConstructixServicesContext.Object);

            var mockRepository = new Mock<OrderRepository>();
            mockRepository.Setup(x => x.Add(It.IsAny<Order>()));
            
            OrderService svc = new OrderService(orderFactory, orderRepository);
            svc.Create(orderFactoryInputData);

            mockConstructixServicesContext.Verify(x=>x.Orders.Add(It.IsAny<Order>()), Times.Once);
        }
    }
}