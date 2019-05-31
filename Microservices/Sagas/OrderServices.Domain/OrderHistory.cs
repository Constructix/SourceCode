using System;

namespace OrderServices.Domain
{
    public class OrderHistory
    {
        public DateTime Created { get; set; }
        public string Event { get; set; }
        public string Notes { get; set; }
    }
}