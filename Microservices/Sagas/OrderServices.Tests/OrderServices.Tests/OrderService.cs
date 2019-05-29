using System;
using System.Collections.Generic;

namespace OrderServices.Tests
{
    public class OrderService
    {
        // Internal 
        private readonly List<Order> _orders;

        public OrderService()
        {
            _orders = new List<Order>();
        }

        internal List<Order> GetAll()
        {
            return _orders;
        }

        internal bool CancelOrder(Order newOrder)
        {
            var foundOrder = _orders.Find(x => x.Id.Equals(newOrder.Id));

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
