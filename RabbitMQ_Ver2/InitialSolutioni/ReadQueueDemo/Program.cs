using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Common;

namespace ReadQueueDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var connection = BuildConnection();
            IModel channel = connection.CreateModel();

            // Firstly need to make sure Exchange, Queue and Hook up Exchange to Queue.
            channel.ExchangeDeclare(RabbitMqSettings.ExchangeName, ExchangeType.Direct);
            channel.QueueDeclare(RabbitMqSettings.QueueName, false, false, false, null);
            channel.QueueBind(RabbitMqSettings.QueueName,
                                RabbitMqSettings.ExchangeName, 
                                RabbitMqSettings.RoutingKeyName, null);


            // now go and get the Message off the queue.
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += Consumer_Received;
            channel.BasicConsume("FirstQueue", true, consumer);
            Console.WriteLine("Completed Reading all messages in queue.");
        }

        private static IConnection BuildConnection()
        {
            ConnectionFactory factory = new ConnectionFactory();
            IConnection connection = factory.CreateConnection();
            return connection;
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;
            var message = Encoding.ASCII.GetString(body);
            Payload payload = JsonConvert.DeserializeObject<Payload>(message);
            Console.WriteLine($"Received : {payload.Created} {payload.Message}");
        }
    }
}
