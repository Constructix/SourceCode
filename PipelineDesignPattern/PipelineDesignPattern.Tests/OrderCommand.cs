using System;

namespace PipelineDesignPattern.Tests
{
    public class OrderCommand : BaseCommand
    {
        public Order Order { get; set; }

        
    }

    public class Order
    {
        public Guid Id { get; set; }
    }
}