using System;
using System.Collections.Generic;

namespace EventDemo
{
    public class OrderManager
    {

        public event EventHandler<OrderEventArgs> OrderEvent;
        public event EventHandler<OrderEventArgs> OrderDeletedEvent;

        private List<Order> Orders { get; set; }
        public int TotalOrders => Orders.Count;

        public OrderManager(List<Order> orders)
        {
            Orders = orders ?? new List<Order>();
        }

        #region Methods
        public Order CreateOrder()
        {
            var orderBuilder = new OrderBuilder();
            var testOrder = orderBuilder
                                        .SetId(Guid.NewGuid())
                                        .SetCreated()
                                        .Build();

            Order newOrder = new Order() { Id = Guid.NewGuid(), Created = DateTime.Now, Status = OrderStatus.Created };
            Orders.Add(newOrder);
            OrderEventArgs orderCreatedEvent = new OrderEventArgs(newOrder) {Message = "Order has been created."};
            OnOrderCreated(orderCreatedEvent);


            return newOrder;

        }
        public Order CreateOrder(Guid Id )
        {
            var orderBuilder = new OrderBuilder();
            var newOrder  = orderBuilder
                                .SetId(Id)
                                .SetCreated()
                                .Build();
            Orders.Add(newOrder);
            OrderEventArgs orderCreatedEvent = new OrderEventArgs(newOrder) {Message = "Order has been created."};
            OnOrderCreated(orderCreatedEvent);


            return newOrder;

        }

        public void DeleteOrder(Order orderToBeDeleted)
        {
            var order = Orders.Find(x => x.Id.Equals(orderToBeDeleted.Id));
            if (order != null)
            {
                // remove from list and raise an event to indicate order has been deleted from list.
                Orders.Remove(order);
                OrderEventArgs orderDeletedEvent = new OrderEventArgs(order);
                orderDeletedEvent.Message = "-- Order has been DELETED.--";
                orderDeletedEvent.Order.Status = OrderStatus.Deleted;
                orderDeletedEvent.Order.Deleted = DateTime.Now;
                OnOrderDeleted(orderDeletedEvent);
            }
            else
            {
                throw new  ItemNotFoundException ();
            }
        }
        #endregion

        #region Events
        protected virtual  void OnOrderCreated(OrderEventArgs e)
        {
            EventHandler<OrderEventArgs> handler = OrderEvent;
            handler?.Invoke(this, e);
        }
        protected virtual void OnOrderDeleted(OrderEventArgs orderDeletedEvent)
        {
            EventHandler<OrderEventArgs> handler = OrderDeletedEvent;
            handler!.Invoke(this, orderDeletedEvent);
        }
        #endregion
       

       
    }
}