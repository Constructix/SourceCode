using System;
using System.Collections.Generic;

namespace ProductCreation
{
    class Program
    {
        static void Main(string[] args)
        {            
            var product = new Product(1, "90x90", 123.34m);

            var products = new List<Product> { product };


            Console.WriteLine("Product Demostration");
            
            
            foreach (Product item in products)
            {
                Console.WriteLine(item.Name);
            }



        }
    }
}
