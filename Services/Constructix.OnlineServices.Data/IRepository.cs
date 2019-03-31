using System;
using System.Collections.Generic;

namespace Constructix.OnlineServices.Data
{
    public interface IRepository<T>
    {
        T Get(Guid id);
        List<T> GetAll();
        void Add(T itemToAdd);
        
        void Delete(T itemToDelete);
    }
}