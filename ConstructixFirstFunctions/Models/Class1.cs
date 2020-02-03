using System;

namespace Models
{
    public class OrderResponse
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
    }

    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string Message { get; set; }
    }
}
