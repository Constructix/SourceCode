using System;
using System.Collections.Generic;

namespace RiderWebAPIDemo.Services.Services
{
    public class ProductService : IService<Product>
    {
        private readonly List<Product> _products;

        public ProductService()
        {
            _products = new List<Product> {new Product(Guid.NewGuid(), "90x90", 12.90m)};
        }
        public IEnumerable<Product> GetAll()
        {
            return _products;
        }

        public Product Get(Guid id)
        {
            return _products.Find(x => x.Id.Equals(id));
        }
    }
}