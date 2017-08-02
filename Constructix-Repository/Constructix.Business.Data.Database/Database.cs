using System.Data.Entity;
using Constructix.Business.Data.Entities;

namespace Constructix.Business.Data.Database
{
    public class Database : DbContext
    {

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }

        public Database() : base("DataServices")
        {
            
        }

        public Database(string dataSourceName) : base(dataSourceName)
        {
        }

       
    }
}
