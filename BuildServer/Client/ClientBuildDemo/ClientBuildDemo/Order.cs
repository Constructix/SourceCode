using System;

namespace ClientBuildDemo
{
    public class Order
    {
        public Guid InternalId { get; }
        public DateTime Created {get; set; }


        public Order()
        {
            InternalId = Guid.NewGuid();
            Created = DateTime.Now;
        }
    }
}