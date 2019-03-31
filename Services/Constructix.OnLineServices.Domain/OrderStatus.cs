using System;

namespace Constructix.OnLineServices.Domain
{
    public class OrderStatus
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }

        public OrderStatus()
        {
            
        }
        
    }
}