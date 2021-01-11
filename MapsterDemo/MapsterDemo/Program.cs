using System;
using Mapster;

namespace MapsterDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var src = new Source() {Id = 100};
            var destObject = src.Adapt<Destination>();
            Console.WriteLine($"ID: {destObject.Id}");
            Console.WriteLine($"GUID ID: {destObject.RequestId}");
            // map to an existing object
            Destination destinationObject = new Destination();
            var d  =src.Adapt<Destination>();
            Console.WriteLine($"Destination Id: {d.Id}");
            
        }
    }


    public class Source
    {
        public int Id { get; set; }
        public Guid RequestId { get; set; }
        public Source()
        {
            RequestId = Guid.NewGuid();
        }
    }

    public class Destination
    {
        public int Id { get; set; }
        public Guid RequestId { get; set; }
    }



    public class OrderRequest
    {
        
    }

    public class OrderDTO
    {
        
    }

    public class OrderItem<T> where T : IItem
    {
        public T Item { get; set; }
        public int Quantity { get; set; }    
    }

    public interface IItem
    {
        
    }

    public class Product : IItem
    {
        
    }

    public interface ISubContractor : IItem
    {
        public string Name { get; set; }
        public int DailyRate { get; set; }
    }

    public class Subcontractor : ISubContractor
    {
        public string Name { get; set; }
        public int DailyRate { get; set; }
    }
    
    
}