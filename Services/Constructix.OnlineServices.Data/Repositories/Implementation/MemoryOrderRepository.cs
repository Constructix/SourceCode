using System;
using System.Collections.Generic;
using Constructix.OnLineServices.Domain;

namespace Constructix.OnlineServices.Data
{
    public class MemoryOrderRepository : IRepository<Order>
    {
        private readonly List<Order> orders = new List<Order>();

        public Order Get(Guid id)
        {
            return orders.Find(x => x.Id.Equals(id));
        }

        public List<Order> GetAll()
        {

            return orders;
        }

        public void Add(Order itemToAdd)
        {
            orders.Add(itemToAdd);
        }

        public void Delete(Order itemToDelete)
        {
            var item = Get(itemToDelete.Id);
            if (item != null)
                orders.Remove(item);
        }
    }
}