using System.Data.Entity.Migrations;
using GenericRepositoryDemo.Contexts;

namespace GenericRepositoryDemo.Migrations
{
    internal sealed class ConfigurationCustomer : DbMigrationsConfiguration<CustomerContext>
    {
        public ConfigurationCustomer()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CustomerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}