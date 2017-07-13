using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Constructix.Business.Data.Entities;

namespace Constructix.Repository.Console.Demo
{
    public interface IOrderRepository
    {
        void Add(Order newOrder);
        IQueryable<Order> Get(Expression<Func<Order, bool>> predicate);
        IList<Order> GetAll();
        void Remove(Guid orderId);
        void Remove(Order removeOrder);
        void Save();
    }


    public class GenericRepository<T, I, C> where T : class, new()  where C : DbContext
    {
        private readonly C _database;

        public GenericRepository()
        {
        }

        public GenericRepository(C database)
        {
            _database = database;
        }
        
        public void Save()
        {
            _database.SaveChanges();
        }

        public void Add(T entity)
        {
            _database.Set<T>().Add(entity);
        }

        public void Remove(T entity)
        {
            _database.Set<T>().Remove(entity);
        }

        public IList<T> GetAll()
        {
            return _database.Set<T>().ToList();
        }

        public IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _database.Set<T>().Where(predicate);
        }
    }
}