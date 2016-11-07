using System.Data.Entity;

namespace BaseServiceTest
{
    public class OnLineServicesContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }


        public OnLineServicesContext() : base("ConstructixServicesConnection")
        {

        }
    }
}