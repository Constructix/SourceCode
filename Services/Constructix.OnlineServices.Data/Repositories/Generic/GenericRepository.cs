using System;
using System.Collections.Generic;

namespace Constructix.OnlineServices.Data
{
    public class GenericRepository<T> : IRepository<T>
    {
        public T Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(T itemToAdd)
        {
            throw new NotImplementedException();
        }

        public void Delete(T itemToDelete)
        {
            throw new NotImplementedException();
        }
    }
}