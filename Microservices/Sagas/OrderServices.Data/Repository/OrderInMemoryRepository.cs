using System;
using System.Collections.Generic;
using OrderServices.Domain;

namespace OrderServices.Data
{
    public class OrderInMemoryRepository : IRepository<Order,Guid>
    {
        private readonly List<Order> _orders;

        public OrderInMemoryRepository()
        {
            _orders=  new List<Order>();
        }

        public List<Order> GetAll() => _orders;

        public void Add(Order newItemToAdd)
        {
            _orders.Add(newItemToAdd);
        }
        
        public Order Find(Guid Id)
        {
            return _orders.Find(x => x.Id.Equals(Id));
        }
    }
}