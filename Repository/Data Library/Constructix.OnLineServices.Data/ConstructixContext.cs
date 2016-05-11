using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Constructix.OnLineServices.Data.Contracts;

namespace Constructix.OnLineServices.Data
{
    public class ConstructixContext : DbContext
    {

        public ConstructixContext() :
            base("name=ConstructixServices")
        {
            //Database.SetInitializer<ConstructixContext>(null);
        }


        public DbSet<ProductCategory> ProductCategorySet { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<ProductCategory>().HasKey<int>(x => x.Id);
            modelBuilder.Entity<ProductCategory>().Map(x => x.ToTable("ProductCategory"));
        }
    }
}
