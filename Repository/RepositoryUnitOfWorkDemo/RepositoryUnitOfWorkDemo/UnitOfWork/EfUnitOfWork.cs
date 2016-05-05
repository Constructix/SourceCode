using System.Data.Entity;

namespace RepositoryUnitOfWorkDemo
{
    public class EfUnitOfWork : DbContext, IUnitOfWork
    {

        private GenericRepository<Order> _orderRepository;
        private GenericRepository<Customer> _customerRepository;
        private GenericRepository<Employee> _employeeRepository;


        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public EfUnitOfWork() : base("name=RepositoryDemo")
        {
            _orderRepository = new GenericRepository<Order>(Orders);
            _customerRepository =new GenericRepository<Customer>(Customers);
            _employeeRepository = new GenericRepository<Employee>(Employees);
        }


        public IGenericRepository<Order> OrderRepository
        { get { return _orderRepository; } }
        public IGenericRepository<Customer> CustomeRepository { get { return _customerRepository; } }
        public IGenericRepository<Employee> EmployeeRepository { get {return _employeeRepository;} }
        public void Commit()
        {
            base.SaveChanges();
        }
    }
}