using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace OrderingEventsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderItem oi = new OrderItem {Id = "12", Name = "First", UnitPrice = 9.00m, Quantity = 2};

            Console.WriteLine($"{oi.Total(),10:C2}");
            Console.WriteLine($"{oi.TotalPlusGst(.10m),10:C2}");

            var order = new Order {Created = DateTimeOffset.Now};
            var address = new Address
                {
                    Street = "11 Carbine Court", 
                    Suburb = "Karalee", 
                    State = "QLD", 
                    Postcode = "4306"

                };
            var orderItems = new List<OrderItem>() { oi};

            var orderStartedEvent = new OrderStartedEvent(order, address, orderItems);

            var events = new List<IBusinessEvent>();
            var eventLogger = new EventLogger(events);

            eventLogger.Add(orderStartedEvent);

            eventLogger.Save(@"D:\Files\Eventlogs.json");
        }
    }



    public class Order
    {

        public DateTimeOffset Created { get; set; }

        
    }

    public class Address
    {
        public string Street { get; set; }
        public string Street2 { get; set; }
        public string Suburb { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
    }

    public class OrderItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }


        public decimal Total() => (decimal) UnitPrice * Quantity;

        public decimal TotalPlusGst(decimal GSTRate) => Total() * (1 + GSTRate);
    }


    public interface IBusinessEvent
    {

    }

    public class OrderStartedEvent : IBusinessEvent
    {
        public Order Order { get; set; }
        public Address Address { get; set; }
        public List<OrderItem> OrderItems { get; set; }


        public OrderStartedEvent(Order order, Address address, List<OrderItem> orderItems)
        {
            Order = order;
            Address = address;
            OrderItems = orderItems;
        }
    }

    public class EventLogger<T> where T : OrderStartedEvent
    {
        public List<T> _events;


        public EventLogger(List<T> events)
        {
            _events = events;
        }

        public void Add(T domainEvent)
        {
            _events ??= new List<T>();

            _events.Add(domainEvent);

            if (File.Exists(@"D:\Files\eventSource.json"))
            {
                var contents = File.ReadAllText(@"D:\Files\eventSource.json");



            }
            else
            {
                
            }


        }


        public void Save(string fileLocation)
        {
            var fileEventLog = new FileEventLog<OrderStartedEvent>();
            



        }
    }

    public class FileEventLog<T> where T : IBusinessEvent
    {
        public List<T> Events { get; set; }

        public FileEventLog()
        {
            Events = new List<T>();
        }
        public FileEventLog(List<T> events)
        {
            Events = events;
        }
    }
}
