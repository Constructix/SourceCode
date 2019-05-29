using System.Collections.Generic;

namespace OrderServices.Data
{
    public interface IRepository<T, K>
    {
        List<T> GetAll();
        void Add(T newItemToAdd);
        T Find(K itemKey);
    }
}