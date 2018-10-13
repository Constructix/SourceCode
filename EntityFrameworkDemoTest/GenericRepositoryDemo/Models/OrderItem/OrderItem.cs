using System;
using GenericRepositoryDemo.Models.Interfaces;

namespace GenericRepositoryDemo.Models.OrderItem
{
    public class OrderItem : IEntity<Guid>
    {
        public int OrderId {get; set; }
        public virtual  Order.Order Order { get; set; }

        public int QuantityRequired { get; set; }
    
        public Guid Id { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastModified { get; set; }

        public OrderItem()
        {
            Created = DateTime.Now;
            LastModified = DateTime.Now;
            Id = Guid.NewGuid();
        }

        public OrderItem(Guid id, DateTime created, DateTime lastModified, int quantityRequiredRequired)
        {
            Id = id;
            Created = created;
            LastModified = lastModified;
            this.QuantityRequired = quantityRequiredRequired;
        }
    }
}