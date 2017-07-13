using System;
using System.Collections.Generic;

namespace Constructix.Business.Data.Entities
{
    public class Order : IEntity<Guid>
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        public ICollection<OrderItem> OrderedItems { get; set; }

       
        public virtual Supplier Supplier { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
            this.Supplier = new Supplier();
        }
    }
}