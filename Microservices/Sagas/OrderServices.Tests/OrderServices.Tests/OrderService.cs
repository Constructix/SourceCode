using System;
using System.Collections.Generic;

namespace OrderServices.Tests
{
    public class OrderService
    {
        // Internal 
        
        private IRepository<Order, Guid> _orders;
        public OrderService(IRepository<Order, Guid> orders)
        {
            _orders = orders;
        }

        internal List<Order> GetAll()
        {
            return _orders.GetAll();
        }

        internal bool CancelOrder(Order newOrder)
        {
            var foundOrder = _orders.Find(newOrder.Id);

            if (foundOrder != null)
            {
                foundOrder.CancelledOn = DateTime.Now.ToUniversalTime();
                foundOrder.Status = OrderStatus.Cancelled;
                return true;
            }
            return false;
        }

        internal Order CreateOrder()
        {
            var newOrder = new Order();
            _orders.Add(newOrder);
            return newOrder;
        }
    }
}
