using System;
using System.Collections.Generic;
using MicroServices.DTO;

namespace MicroServicesDemo
{

    public class ServiceManager
    {
        public void StartServices()
        {
        }

        public void StartService(string serviceName)
        {
        }

        public void StopServices()
        {
            
        }

        public void StopService(string serviceName)
        {
        }


        public int ServiceInstances(string serviceName)
        {
            return 0;
        }


    }


    public abstract class ServiceMonitor
    {
        public void ShutDownAllServices()
        {
        }

        public List<string> ServicesStatus(string serviceType)
        {
            return new List<string>();

        }

    }

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