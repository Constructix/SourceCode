using System;
using Xunit;
using Shouldly;

namespace OrderServices.Tests
{
    public class OrderServiceTests
    {
        private IRepository<Order, Guid> ordersRepository;
        private OrderService orderSvc;
        public OrderServiceTests()
        {
            ordersRepository = new OrderInMemoryRepository();
            ordersRepository.Add(new Order());
            ordersRepository.Add(new Order());
            ordersRepository.Add(new Order());
            ordersRepository.Add(new Order());
            ordersRepository.Add(new Order());
            ordersRepository.Add(new Order());
            ordersRepository.Add(new Order());
            ordersRepository.Add(new Order());
            ordersRepository.Add(new Order());
            orderSvc = new OrderService(ordersRepository);
        }

        [Fact]
        public void ListAllOrders()
        {
            orderSvc.CreateOrder();
            orderSvc.GetAll().Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public void InstanceCreated_NoExceptionIsExpected()
        {            
            orderSvc.ShouldNotBeNull();
        }

        [Fact]
        public void CreateOrder_OrderInstanceIsReturned_NoExceptionExpected()
        {          
            var newOrder = orderSvc.CreateOrder();
            newOrder.ShouldBeOfType<Order>();
        }

        [Fact]
        public void CancelOrder_ValidOrderIsSubmitted_OrderIsRemoved_FromOrderService_Successfully()
        {
            var newOrder = orderSvc.CreateOrder();
            var IsOrderCancelled = orderSvc.CancelOrder(newOrder);
            IsOrderCancelled.ShouldBe(true);
        }
        [Fact]
        public void CancelExistingOrder_BooleanValueReturnedShouldBeFalseIndicatingOrderHasNotBeenCancelledSuccessfully()
        {
            var newOrder = new Order();            
            var IsOrderCancelled = orderSvc.CancelOrder(newOrder);
            IsOrderCancelled.ShouldBe(false);

        }
    }
}
