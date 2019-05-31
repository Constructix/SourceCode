using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
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



    public class GenericRepository<C, E> where C : DbContext where E : class
    {
    }



    public class GenericContext<T> : DbContext where T : class
    {
        public DbSet<T> Entities { get; set; }


        


    }

    public class OrdersContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }



        public OrdersContext()
        {
            
        }
    }

} 