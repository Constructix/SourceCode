using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace TopicSender
{
    class Program
    {
        static void Main(string[] args)
        {
            var topicName = "testTopic";
            var connectionString = "Endpoint=sb://constructixonlineservices.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=663cqcIQtlczP/GPUkO4RKNHH4nwTxPBJQvDRCUdXCQ=";


            // 1st Way -  this is the first way of declaring a topic
            // configure topic setting
            TopicDescription td = new TopicDescription(topicName);
            td.MaxSizeInMegabytes = 5120;
            td.DefaultMessageTimeToLive = new TimeSpan(0, 1, 0);

            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
            if (!namespaceManager.TopicExists(topicName))
            {
                namespaceManager.CreateTopic(td);
                Console.WriteLine("Topic Created...");
            }


            // 2nd Way 
            //var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);
            //if (!namespaceManager.TopicExists(topicName))
            //    namespaceManager.CreateTopic(testTopic);


            // Create subscription
            if (!namespaceManager.SubscriptionExists(topicName, "AllMessages"))
            {
                namespaceManager.CreateSubscription(topicName, "AllMessages");
                Console.WriteLine("All messages subcription has been created.");
            }
            else
            {
                Console.WriteLine("All messages Subscription exists..");
            }




            // send to topic
            TopicClient client = TopicClient.CreateFromConnectionString(connectionString, topicName);

            for (int i = 0; i < 20; i++)
            {
                var body = string.Format($"Test Message: MessageID: {i}");
                BrokeredMessage message = new BrokeredMessage(body);
                Console.WriteLine("Sending Message");
                client.Send(message);
                Console.WriteLine("Sent Message");
            }
            Console.WriteLine();
            Console.WriteLine("Messages sent...");
        }
    }
}
