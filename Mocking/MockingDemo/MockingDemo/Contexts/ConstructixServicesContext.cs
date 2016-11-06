using System.Data.Entity;

namespace MockingDemo
{
    public class ConstructixServicesContext : DbContext
    {

        public ConstructixServicesContext() : base("ConstructixServicesConnection")
        {
            
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }

        public virtual DbSet<Order> Orders { get; set; }
    }
}