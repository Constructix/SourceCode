using System;

namespace WebApplication1.Models
{

    public enum OrderItemStatus
    {
        Ok,
        Warning, 
        Error
    }

    public class OrderItem
    {
        public Guid Id { get; set; }
        public DateTime DateTimeStamp { get; set; }
        public OrderItemStatus Status { get; set; }

        public OrderItem()
        {
            Id =Guid.NewGuid();
            DateTimeStamp = DateTime.Now;

            
        }

        public OrderItem(Guid id, DateTime dateTimeStamp, OrderItemStatus status)
        {
            Id = id;
            DateTimeStamp = dateTimeStamp;
            Status = status;
        }
    }
}