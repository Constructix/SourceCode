using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MassTransit.Data;
using MassTransit.MessageContract;

namespace MassTransit.MessageConsumerDemo
{
    class Program
    {
        static  void Main(string[] args)
        {

            Console.WriteLine("MassTransit.MessageConsumerDemo is running......");

            var timeStamp = DateTime.Now;
            var timeStampAsString  = string.Format($"{timeStamp.ToString("s")}{timeStamp.ToString("zzz")}");
            Console.WriteLine($"Started on  {timeStampAsString}");
            var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
            {
                var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
                {
                    h.Username("guest");
                    h.Password("guest");
                });

                cfg.ReceiveEndpoint(host, "customer_update_queue", e =>
                {
                    e.Consumer<UpdateCustomerConsumer>();
                });

            });

            busControl.Start();
            Console.WriteLine("Press 'q' to end service.");
            while ('q' != Console.ReadKey().KeyChar ) ;
            Console.WriteLine();
        }
    }

    //public class SendCustomeerDetailsPublisher
    //{
    //    public async void Send(IBusControl bus, IUpdateCustomerAddress addressDetails)
    //    {

         


    //         await bus.Publish<IUpdateCustomerAddress>(addressDetails);
    //    }
    //}



    public class UpdateCustomerConsumer : IConsumer<IUpdateCustomerAddress>
    {

        public UpdateCustomerConsumer()
        {
           
        }


        public async Task Consume(ConsumeContext<IUpdateCustomerAddress> context)
        {
            // Mapping from Message object to a DTO to go here.
            AddressDetails addressDetails = new AddressDetails { Id = context.Message.CommandId,
                                                                 CustomerId = context.Message.CustomerId,
                                                                 Created = context.Message.Timestamp};

            using (MassTransitContext _db = new MassTransitContext())
            {
                _db.AddressDetails.Add(addressDetails);
                _db.SaveChanges();
            }

            await Console.Out.WriteLineAsync($"Updating customer: {context.Message.CommandId}");
           
            // write to file for test purpose.
            DateTime currentDateTimeReceived = DateTime.Now;
            StringBuilder resultBuilder = new StringBuilder();
            resultBuilder.AppendLine();
            resultBuilder.AppendFormat($"Received: {currentDateTimeReceived.ToString()} Id: {context.Message.CommandId} CustId: {context.Message.CustomerId}");

            System.IO.File.AppendAllText(@"D:\Temp\RabbitMQDemo.txt", resultBuilder.ToString());


            
        }
    }

    
}
