using System.Collections.Generic;

namespace Constructix.Core.Contracts.Data
{
    public interface IDataRepository
    {
         
    }
    public interface IDataRepository<T> : IDataRepository where T : class, new()
    {
        T Add(T entity);

        void Remove(T entity);

        void Remove(int Id);

        T Update(T entity);
        IEnumerable<T> Get();

        T Get(int id);
    }
}