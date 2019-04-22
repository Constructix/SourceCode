using System;
using System.Collections.Generic;

namespace RiderWebAPIDemo.Services.Services
{
    public class ProductService : IService<Product>
    {
        private readonly List<Product> products;

        public ProductService()
        {
            products = new List<Product> {new Product(Guid.NewGuid(), "90x90", 12.90m)};
        }
        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public Product Get(Guid id)
        {
            return products.Find(x => x.Id.Equals(id));
        }
    }
}