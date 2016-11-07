using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace BaseServiceTest
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        private OnLineServicesContext _context;


        private List<TEntity> _entities = new List<TEntity>();
        public BaseRepository()
        {
             _entities = new List<TEntity>();
        }

       
        public virtual void Add(TEntity entity)
        {
            _entities.Add(entity);
            Console.WriteLine($"Added {entity.GetType().FullName}");
        }

        public void Remove(TEntity entity)
        {
            _entities.Remove(entity);
        }

        public IQueryable<TEntity> Get(Func<TEntity, bool> query)
        {
            return _entities.Where(query).AsQueryable();
        }

        public IEnumerable<TEntity> Get()
        {
            return _entities.ToList();
        }
    }
}