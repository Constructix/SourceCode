using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
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
