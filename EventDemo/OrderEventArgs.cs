using System;

namespace EventDemo
{
    public class OrderEventArgs : EventArgs
    {
        public Order Order { get; set; }
        public string Message { get; set; }

        public OrderEventArgs(Order order)
        {
            Order = order;
        }
    }
}