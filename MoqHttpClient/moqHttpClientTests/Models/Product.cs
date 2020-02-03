using System;

namespace moqHttpClientTests.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime EffectiveFrom { get; set; }

        public  Product()
        {
            
        }
        public Product(Guid id, DateTime created, DateTime effectiveFrom)
        {
            this.Id = id;
            Created = created;
            EffectiveFrom = effectiveFrom;
        }
    }
}