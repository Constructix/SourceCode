using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Constructix.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T :class
    {
        private readonly IDbSet<T> _dbset;


        public GenericRepository()
        {
            
        }

        public GenericRepository(IDbSet<T> dbset )
        {
            _dbset = dbset;
        }

        public IQueryable<T> AsQueryable()
        {
            return _dbset.AsQueryable();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbset;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Where(predicate);
        }

        public T Single(Expression<Func<T, bool>> predicate)
        {
            return _dbset.Single(predicate);
        }

        public T SingleOrDefault(Expression<Func<T, bool>> predicate)
        {
            return _dbset.FirstOrDefault(predicate);
        }

        public T First(Expression<Func<T, bool>> predicate)
        {
            return _dbset.First(predicate);
        }

        public T GetById(int id)
        {
            return _dbset.Find(id);
        }

        public void Add(T entity)
        {
            _dbset.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public void Attach(T entity)
        {
            _dbset.Attach(entity);
        }
    }
}