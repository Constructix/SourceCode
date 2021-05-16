using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using OrdersDomain;
using Serilog;
using Serilog.Events;

namespace ReceiveOrdersFromServiceBusDemo
{
    class Program
    {
        private const string ServiceBusConnectionString = "Endpoint=sb://constructix-svc-bsns-suppliers.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=e5cyQ7s3t0kwEaaEpCGFGSyllXP3qCE5agWhPUwm3M4=";
        private const string QueueName = "suppliers";

        
        static async Task Main(string[] args)
        {
            await ReceiveMessageAsync();
        }


        private async static Task ReceiveMessageAsync()
        {
            await using (ServiceBusClient svcBusClient = new ServiceBusClient(ServiceBusConnectionString))
            {
                ServiceBusProcessor processor = svcBusClient.CreateProcessor(QueueName, new ServiceBusProcessorOptions());

                processor.ProcessMessageAsync += Processor_ProcessMessageAsync;
                processor.ProcessErrorAsync += ErrorHandler;
                processor.StartProcessingAsync();


                Console.WriteLine("Reading from queue to obtain orders from the orders queue.");
                Console.ReadLine();

                Console.WriteLine("Stopping the receiver.....");
                await processor.StopProcessingAsync();
                Console.WriteLine("Stopping the queue...");

            }
        }

        private static Task ErrorHandler(ProcessErrorEventArgs arg)
        {
            
            Console.WriteLine($"\tError Encountered: {arg.Exception.Message}");
            return  Task.CompletedTask;
        }

        private static async Task Processor_ProcessMessageAsync(ProcessMessageEventArgs arg)
        {
            string body = arg.Message.Body.ToString();
            var order = Newtonsoft.Json.JsonConvert.DeserializeObject<Order> (body);
            Console.WriteLine($"{order.Id} - {order.Created.ToString()}");
            await arg.CompleteMessageAsync(arg.Message);
        }


      
    }
}
