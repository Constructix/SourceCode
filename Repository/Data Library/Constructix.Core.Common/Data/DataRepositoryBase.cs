using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Constructix.Core.Contracts.Data;

namespace Constructix.Core.Common.Data
{
    public abstract class DataRepositoryBase<T, U> : IDataRepository<T>
        where T : class, new()
        where U : DbContext, new()
    {


        protected abstract T AddEntity(U entityContext, T entity);
        protected abstract T UpdateEntity(U entityContext, T entity);
        protected abstract IEnumerable<T> GetEntities(U entityContext);
        protected abstract T GetEntity(U entityContext, int id);


        public T Add(T entity)
        {
            using (U entityContext = new U())
            {
                T addedEntity = AddEntity(entityContext, entity);
                entityContext.SaveChanges();
                return addedEntity;
            }
        }

        public void Remove(T entity)
        {
            using (U entityContext = new U())
            {
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public void Remove(int Id)
        {
            using (U entityContext = new U())
            {
                T entity = GetEntity(entityContext, Id);
                entityContext.Entry<T>(entity).State = EntityState.Deleted;
                entityContext.SaveChanges();
            }
        }

        public T Update(T entity)
        {
            using (U entityContext = new U())
            {
                entityContext.Entry<T>(entity).State = EntityState.Modified;
                entityContext.SaveChanges();
                return entity;  
            }
        }

        public IEnumerable<T> Get()
        {
            using (U entityContext = new U())
            {
                return GetEntities(entityContext).ToArray().ToList();
            }
        }

        public T Get(int id)
        {
            using (U entityContext = new U())
            {
                return GetEntity(entityContext, id);
            }
        }
    }
}