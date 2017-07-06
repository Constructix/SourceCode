using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace TopicReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            var connnectionString = "Endpoint=sb://constructixonlineservices.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=663cqcIQtlczP/GPUkO4RKNHH4nwTxPBJQvDRCUdXCQ=";

            Console.WriteLine("Message Receiver");
            SubscriptionClient client =  SubscriptionClient.CreateFromConnectionString(connnectionString,"testTopic","AllMessages");

            // configure the callback options.

            OnMessageOptions options = new OnMessageOptions();
            options.AutoComplete = false;
            options.AutoRenewTimeout = TimeSpan.FromMinutes(1);




            var brokerageMessage = client.Receive();

            if (brokerageMessage != null)
            {
                var body = brokerageMessage.GetBody<string>();
                Console.WriteLine(body);
            }



            
            client.OnMessage((message) =>
            {

                var body = message.GetBody<string>();
                message.Complete();
                Console.WriteLine(body);
                //try
                //{
                //    Console.WriteLine("\n Messages");
                //    Console.WriteLine($"Body: {message.GetBody<string>()}");
                //    Console.WriteLine($"Message Id: {message.MessageId}");
                //    Console.WriteLine($"Message Number: {message.Properties["MessageNumber"]}");

                //    message.Complete();
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //    message.Abandon();
                //}
            },options);


            while (true) { }
        }
    }
}
