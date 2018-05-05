using System.Data.Entity;
using GenericRepositoryDemo.Models.Order;
using GenericRepositoryDemo.Models.OrderItem;

namespace GenericRepositoryDemo.Contexts
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("Data Source=ZEUS;Initial Catalog=Orders;Integrated Security=SSPI;")
        {
            
        }

        public OrderContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get;set; }
    }
}