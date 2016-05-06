using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Constructix.Data.Repositories;
using Constructix.OnLineServices.Contracts;

namespace Constructix.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Order> OrderRepository { get; }

        void Commit();
    }
}
