using System;

namespace WebApplication1.Models
{
    public class OrderRequest
    {
        public Guid Id { get; set; }
        public DateTime DateTimeStamp { get; set; }

        public Order Order { get; set; }

        public OrderRequest()
        {
            
        }

        public OrderRequest(Guid id, DateTime dateTimeStamp, Order order)
        {
            Id = id;
            DateTimeStamp = dateTimeStamp;
            Order = order;
        }
    }
}