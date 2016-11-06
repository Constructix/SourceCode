using System;

namespace MockingDemo
{
   

    public class OrderFactoryInputData : IOrderFactoryInputData
    {
        public DateTime Created { get; set; }
        public Customer Customer { get; set; }
    }
}