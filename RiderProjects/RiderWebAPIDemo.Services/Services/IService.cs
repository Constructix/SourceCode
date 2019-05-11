using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RiderWebAPIDemo.Services.Services
{
    public interface IService<T>
    {
        IEnumerable<Product> GetAll();
        T Get(Guid id);
    }
}