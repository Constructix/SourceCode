using System.Data.Entity;
using GenericRepositoryDemo.Models.Customers;

namespace GenericRepositoryDemo.Contexts
{
    public class CustomerContext : DbContext
    {
        public CustomerContext() : base("Data Source=ZEUS;Initial Catalog=Customers;Integrated Security=SSPI;")
        {

        }

        public CustomerContext(string connectionString) : base(connectionString) { }
        public DbSet<Customer> Customers { get; set; }
    }
}