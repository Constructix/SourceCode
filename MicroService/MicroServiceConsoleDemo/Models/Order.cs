using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp1
{
    public class Order
    {
        [Key]
        public Guid Id { get; }

        public OrderStatus Status { get; set; }
        public Order()
        {
            
        }
        public Order(Guid id, OrderStatus status)
        {
            this.Id = id;
            this.Status = status;
        }
    }


    public class OrderStatus
    {
        public static OrderStatus Pending => new OrderStatus("Pending");
        public static OrderStatus Approved => new OrderStatus("Approved");
        public static OrderStatus Rejected => new OrderStatus("Rejected");

        public OrderStatus(string value)
        {
            this.Value = value;
        }

        public static bool operator ==(OrderStatus status1, OrderStatus status2)
        {
            return status1.Value.Equals(status2.Value);
        }
        public static bool operator !=(OrderStatus status1, OrderStatus status2)
        {
            return !status1.Value.Equals(status2.Value);
        }

        public override bool Equals(object obj)
        {
            if (obj is OrderStatus status)
            {
                return this.Value.Equals(status.Value);
            }
            return false;
        }

        public string Value { get; set; }
    }
}