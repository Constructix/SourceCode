using System;

namespace Constructix.OnLineServices.Domain
{
    public class OrderLine
    {
        public int LineOrderNumber { get; set; }
        public Guid OrderId { get; set; }

        public OrderLine()
        {
            
        }

        public OrderLine(int lineOrderNumber, Guid orderId)
        {
            LineOrderNumber = lineOrderNumber;
            OrderId = orderId;
        }
    }
}