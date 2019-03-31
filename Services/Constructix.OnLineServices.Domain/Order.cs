using System;

namespace Constructix.OnLineServices.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime  LastUpdated{ get; set; }

        public Order()
        {
            this.Id =  Guid.NewGuid();
            this.CreateDateTime =DateTime.Now;
            this.LastUpdated = DateTime.Now;
        }

        public Order(Guid id, DateTime dateTime, DateTime lastUpdated)
        {
            Id = id;
            CreateDateTime = dateTime;
            LastUpdated = lastUpdated;
        }
    }
}
