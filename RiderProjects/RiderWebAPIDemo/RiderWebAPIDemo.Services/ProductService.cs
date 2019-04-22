using System;

namespace RiderWebAPIDemo.Services
{
    public class ProductService : IService<Product>
    {
        private static List<Product> _products;

        public ProductService()
        {
            _products= new List<Product>
            {
                new Product(Guid.NewGuid(), DateTime.Now, "Post", 213.33m ),
                new Product(Guid.NewGuid(), DateTime.Now.AddDays(-1), "Decking", 32.45m)
            };
        }
        
        

        public IEnumerable<Product> GetAll()
        {
            return _products;
        }
    }
}