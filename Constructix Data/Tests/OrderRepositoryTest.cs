using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constructix.Data.Repositories;
using Constructix.Data.UnitOfWork;
using Constructix.OnLineServices.Contracts;
using Moq;
using NUnit.Framework;


namespace Constructix.OnLineServices.Tests
{
    [TestFixture]
    public class OrderRepositoryTest
    {
        [Test]
        public void CreateRepository()
        {
            Mock<IGenericRepository<Order>> orderRepositoryMock  = new Mock<IGenericRepository<Order>>();
            var OrderList = SetupOrderList();

            AssignOrderListToGetAllMethod(orderRepositoryMock, OrderList);

            Mock<IUnitOfWork> uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.OrderRepository).Returns(orderRepositoryMock.Object);

            var uow = uowMock.Object;

            Assert.That(uow.OrderRepository.GetAll().Any() == true);
            PrintOrders(uow.OrderRepository.GetAll().ToList());
            
        }

        private static void AssignOrderListToGetAllMethod(Mock<IGenericRepository<Order>> orderRepositoryMock, List<Order> OrderList)
        {
            orderRepositoryMock.Setup(x => x.GetAll()).Returns(OrderList.AsEnumerable());
        }

        private static List<Order> SetupOrderList()
        {
            var OrderList = new List<Order>
            {
                new Order {CustomerName = "Richard Jones", Id = 1},
                new Order {CustomerName = "Bill Jennings", Id = 2},
                new Order {CustomerName = "Teresa Jones", Id = 2},
                new Order {CustomerName = "Steve Gibson", Id = 2}
            };


           
            return OrderList;
        }

        private static void PrintOrders(List<Order> orders)
        {
            foreach (Order order in orders)
            {
                Console.WriteLine($"{order.Id}  {order.CustomerName}");
            }
        }
    }
}
