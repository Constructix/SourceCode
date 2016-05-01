using System.Collections.Generic;

namespace RepositoryDesignPattern
{
    public interface IRepository<T,V> where T : IEntity<V>
    {
        IEnumerable<T> List { get; }
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        T FindById(int id);
    }

   
}