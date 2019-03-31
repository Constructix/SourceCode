using Constructix.OnLineServices.Domain;
using Microsoft.EntityFrameworkCore;

namespace Constructix.OnlineServices.Data.Contexts
{
    public class OrdersContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }


    }
}