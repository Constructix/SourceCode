using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreDemo.Contexts
{
    public class OnLineServicesGeneric : DbContext
    {
        public DbSet<Supplier> Suppliers { get; set;}
        public DbSet<Category> Categories { get; set;}

        public OnLineServicesGeneric()
        {
            
        }

        public OnLineServicesGeneric(DbContextOptionsBuilder<OnLineServicesGeneric> builder) : base(builder.Options)
        {
            
        }
        
    }
}