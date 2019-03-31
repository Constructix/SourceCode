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
    }
}