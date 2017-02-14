using System;
using System.Runtime.Remoting;

namespace Project1
{
    public class Product : IProduct
    {
        private int _quantityRequired;


        public string Id { get; set; }

        public int Quantity { get; set; }
    }
}