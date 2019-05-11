using System;

namespace RiderWebAPIDemo.Services
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }

        public Product()
        {
            
        }
        public Product(Guid id, string name, decimal unitPrice)
        {
            Id = id;
            Name = name;
            UnitPrice = unitPrice;
        }

    }
}