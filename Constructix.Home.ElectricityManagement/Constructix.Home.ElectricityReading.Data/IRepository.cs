using System;
using System.Collections.Generic;

namespace Constructix.Home.ElectricityReading.Data
{
    public interface IRepository<T>
    {

        void Add(T newItem);
        void Remove(T removeItem);

        IEnumerable<T> Get(Func<T, bool> expression);

        IList<T> GetAll();

    }
}