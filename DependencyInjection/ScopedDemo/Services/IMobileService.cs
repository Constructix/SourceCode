using System.Collections.Generic;
using ScopedDemo.Models;

namespace ScopedDemo.Services
{
    public interface IMobileService
    {
        IEnumerable<Mobile> GetAll();
        Mobile Add(Mobile mobile);
    }
}

