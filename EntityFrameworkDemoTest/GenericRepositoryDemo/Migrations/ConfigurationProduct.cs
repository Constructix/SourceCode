using System.Data.Entity.Migrations;
using GenericRepositoryDemo.Contexts;

namespace GenericRepositoryDemo.Migrations
{
    internal sealed class ConfigurationProduct : DbMigrationsConfiguration<ProductContext>
    {
        public ConfigurationProduct()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ProductContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}