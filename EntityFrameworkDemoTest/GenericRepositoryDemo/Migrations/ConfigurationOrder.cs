using GenericRepositoryDemo.Contexts;

namespace GenericRepositoryDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    internal sealed class ConfigurationOrder : DbMigrationsConfiguration<OrderContext>
    {
        public ConfigurationOrder()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(OrderContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
