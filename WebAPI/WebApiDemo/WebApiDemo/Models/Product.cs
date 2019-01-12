using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiDemo.Models
{
    public class Product
    {

        public int Id { get;set;}
        public string Name { get;set; }
        public decimal UnitPrice { get;set;}
        public Product() { }
        public Product(int id, string name, decimal unitPrice)
        {
            Id = id;
            Name = name;
            this.UnitPrice = unitPrice; 
        }
    }
}