using System;
using System.Collections.Generic;

namespace moqHttpClientTests
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<Product> ProductItems { get; set; }

        public Order(Guid id, List<Product> productItems)
        {
            Id = id;
            ProductItems = productItems;
        }
    }
}