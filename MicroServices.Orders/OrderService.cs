using System;
using MicroServices.DTO;
using MicroServicesDemo;

namespace MicroServices.Orders
{
    public class OrderService : BaseMicroService<Order>
    {


        // OrderRepository repo = new Repository()  to go here......


        public override void Start()
        {
            base.Start();
            Console.WriteLine("Order Status has started.....");
        }

        public override void Stop()
        {
            base.Stop();
            Console.WriteLine("Order Service has stopped.");
            
        }
      
        public override void Process(Order instance)
        {
            if (ServiceStatus.Started == this.Status)
            {
                Console.WriteLine("Processing orderservice....");
            }
        }
    }
}