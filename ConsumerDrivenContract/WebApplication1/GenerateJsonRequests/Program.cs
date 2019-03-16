using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WebApplication1.Models;

namespace GenerateJsonRequests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Generating JSON requests.");



            var request = new OrderRequest
            {
                DateTimeStamp = DateTime.Now,
                Order = new Order(Guid.NewGuid(),
                    new List<OrderItem> {new OrderItem {DateTimeStamp = DateTime.Now, Id = Guid.NewGuid()}})
            };


            var jsonString = JsonConvert.SerializeObject(request, Formatting.Indented);

            Console.WriteLine(jsonString);



        }
    }
}
