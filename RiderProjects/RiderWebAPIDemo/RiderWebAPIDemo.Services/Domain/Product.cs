using System;

namespace RiderWebAPIDemo.Services.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public decimal    UnitPrice     { get; set; }

        public Product()
        {
            
        }
        public Product(Guid id , DateTime created, string name, decimal unitPrice)
        {
            Id = id;
            Created = created;
            Name = name;
            UnitPrice = unitPrice;
        }

        public string Name { get; set; }
    }
}