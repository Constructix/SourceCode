using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MassTransit.MessageContract;

namespace MassTransit.MessagePublishDemo
{
    public class PublisherDemo
    {
        public static void Main()
        {

            Console.WriteLine("Publisher sending customer data....");
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username(ConfigurationManager.AppSettings["UserId"]);
                    h.Password(ConfigurationManager.AppSettings["Password"]);
                });
            });
            busControl.Start();
            SendCustomeerDetailsPublisher publisher = new SendCustomeerDetailsPublisher();

            Console.WriteLine("Sending data");
            Random r = new Random((int) DateTime.Now.Ticks);
            for (int i = 0; i < 100; i++)
            {
                var id = r.Next(1000, 9999).ToString();
                var customerAddressData = new UpdateCustomerAdress(Guid.NewGuid(),  id, DateTime.Now);
                Console.WriteLine($"Sending new customer Id value : {customerAddressData.CustomerId}");
                publisher.Send(busControl, customerAddressData);
                System.Threading.Thread.Sleep(500);
            }
            Console.WriteLine("Publishing is complete...");
            Console.WriteLine();
        }
    }
    public class SendCustomeerDetailsPublisher
    {
        public async void Send(IBusControl bus, IUpdateCustomerAddress addressDetails)
        {
            await bus.Publish<IUpdateCustomerAddress>(addressDetails);
        }
    }

}
