using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace QueueSender
{
    class Program
    {
        static void Main(string[] args)
        {

            var connectionString = "Endpoint=sb://constructixonlineservices.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=663cqcIQtlczP/GPUkO4RKNHH4nwTxPBJQvDRCUdXCQ=";
            var queueName = "queuetest1";
            Console.WriteLine("Demostrating using Azure Service Bus.");

            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);


            for (int i = 0; i < 10; i++)
            {
                var message = new BrokeredMessage($"This is a test message {i+1} sent.");
                client.Send(message);
            }
            Console.WriteLine("Message has been sent.");


        }
    }
}
