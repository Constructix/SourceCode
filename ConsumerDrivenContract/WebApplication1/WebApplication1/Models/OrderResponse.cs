using System;

namespace WebApplication1.Models
{
    public class OrderResponse
    {
        public OrderRequest Request { get; set; }
        public Guid ResponseId { get; set; }
        public DateTime DateTimeStamp { get; set; } 

    }
}