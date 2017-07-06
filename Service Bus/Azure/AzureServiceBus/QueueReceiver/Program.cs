using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace QueueReceiver
{
    class Program
    {
        static void Main(string[] args)
        {

            var connectionString = "Endpoint=sb://constructixonlineservices.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=663cqcIQtlczP/GPUkO4RKNHH4nwTxPBJQvDRCUdXCQ=";
            var queueName = "queuetest1";

            Console.WriteLine("Queue Receiver");
            Console.WriteLine("Receiving Queue messages.");


            var client = QueueClient.CreateFromConnectionString(connectionString, queueName);
            client.OnMessage(message =>
            {
                Console.WriteLine(string.Format($"Message Body: { message.GetBody<string>()}"));
                Console.WriteLine(string.Format($"Messgae Id :{message.MessageId}"));
            });



            Console.ReadLine();
        }
    }
}
