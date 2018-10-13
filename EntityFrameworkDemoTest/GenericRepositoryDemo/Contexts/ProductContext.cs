using System.Data.Entity;
using GenericRepositoryDemo.Models.Inventory;

namespace GenericRepositoryDemo.Contexts
{
    public class ProductContext : DbContext
    {
        public ProductContext() : base("Data Source=ZEUS;Initial Catalog=Products;Integrated Security=SSPI;")
        {
            
        }

        public ProductContext(string context) : base(context)
        {
        }

        public DbSet<Product> Products { get; set; }
    
    }
}