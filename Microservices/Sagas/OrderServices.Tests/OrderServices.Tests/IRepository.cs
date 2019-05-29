using System.Collections.Generic;

namespace OrderServices.Tests
{
    public interface IRepository<T, K>
    {
        List<T> GetAll();
        void Add(T newItemToAdd);
        T Find(K itemKey);
    }
}