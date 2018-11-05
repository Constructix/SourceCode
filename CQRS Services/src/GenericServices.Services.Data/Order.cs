using System;
using System.Collections.Generic;

namespace GenericServices.Services.Models
{
    public class Order : IEntity<Guid>, IEqualityComparer<Order>
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public Customer Customer { get; set; }

        public Order(Guid id, DateTime created, Customer customer)
        {
            Id = id;
            Created = created;
            Customer = customer;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public bool Equals(Order x, Order y)
        {
            return x.Id.Equals(y.Id) && x.Customer.Equals(y.Customer);
        }

        public int GetHashCode(Order obj)
        {
            throw new NotImplementedException();
        }
    }
}