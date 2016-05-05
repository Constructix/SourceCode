using System;

namespace RepositoryUnitOfWorkDemo
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Order> OrderRepository { get; }
        IGenericRepository<Customer>  CustomeRepository { get; }
        IGenericRepository<Employee>  EmployeeRepository { get; }

        void Commit();
    }
}