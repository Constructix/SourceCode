using System;
using GenericRepositoryDemo.Models.Interfaces;

namespace GenericRepositoryDemo.Models.Inventory
{
    public class Product : IEntity<int>
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }


        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime? RemovedFromSale { get; set; }


        public Product()
        {
            this.Created= DateTime.Now;
            this.LastModified= DateTime.Now;
        }



    }
}