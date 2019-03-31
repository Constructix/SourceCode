using System;
using System.Collections.Generic;

namespace Constructix.OnLineServices.Services
{
    public interface IService<T>
    {
        T Get(Guid Id);
        bool Add(T itemToAdd);
        List<T> GetAll();
    }
}