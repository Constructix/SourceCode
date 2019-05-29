using System;
using System.Collections.Generic;
using OrderServices.Data;
using OrderServices.Domain;

namespace OrderServices
{
    public class OrderService : IOrderService
    {
        private IRepository<Order, Guid> _orders;
        public OrderService(IRepository<Order, Guid> orders)
        {
            _orders = orders;
        }

        public List<Order> GetAll()
        {
            return _orders.GetAll();
        }

        public bool CancelOrder(Order newOrder)
        {
            var orderFound = _orders.Find(newOrder.Id);

            if (orderFound != null)
            {
                orderFound.CancelledOn = DateTime.Now.ToUniversalTime();
                orderFound.Status = OrderStatus.Cancelled;
                return true;
            }
            return false;
        }

        public Order CreateOrder()
        {
            var newOrder = new Order();
            _orders.Add(newOrder);
            return newOrder;
        }
    }
}
