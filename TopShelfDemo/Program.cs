using System;
using System.Threading;
using Newtonsoft.Json;
using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace TopShelfDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderService svc = new OrderService();

            svc.Start();

            Thread.Sleep(3000);

            svc.Process(new Order());

            svc.Stop();
        }
    }

    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }

        public Order()
        {
            Id = Guid.NewGuid();
            Created = DateTime.Now;
        }

        public Order(Guid id, DateTime created)
        {
            Id = id;
            Created = created;
        }
    }

    public class OrderService
    {
        private readonly Logger _log;

        public OrderService()
        {
            _log = new LoggerConfiguration()
                .WriteTo.File(path: @"D:\Files\OrderService.log", LogEventLevel.Information,
                    rollingInterval: RollingInterval.Day)
                .WriteTo.Console()
                .CreateLogger();
        }

        public void Process(Order newOrder)
        {
            var orderAsString = JsonConvert.SerializeObject(newOrder);
            _log.Information($"[OrderSvc] - Process - New Order Processing");
            _log.Information($"[OrderSvc] - OrderDetails - {orderAsString}");

            
        }


        public void Start()
        {
            _log.Information($"[OrderSvc] - Starting Service.");
        }

        public void Stop()
        {
            _log.Information($"[OrderSvc] - Stopping Service.");
        }
    }
}
