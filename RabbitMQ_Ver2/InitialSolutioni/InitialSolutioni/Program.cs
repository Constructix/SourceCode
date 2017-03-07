using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Common;
using static System.Text.ASCIIEncoding;

namespace InitialSolutioni
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionFactory factory = new ConnectionFactory();
            IConnection connection = factory.CreateConnection();
            IModel channel = connection.CreateModel();

            // Firstly need to make sure Exchange, Queue and Hook up Exchange to Queue.
            channel.ExchangeDeclare("FirstRabbitMQExchange", ExchangeType.Direct);
            channel.QueueDeclare("FirstQueue", false, false, false, null);
            channel.QueueBind("FirstQueue", "FirstRabbitMQExchange", "first", null);


            for(int i = 0; i < 10; i++)
            {

                var payload = new Payload {Created = DateTime.Now, Message = "This is the payload Message"};
                // serialise the payload

                var payloadAsJson = JsonConvert.SerializeObject(payload);

                Console.WriteLine(payloadAsJson);
                Console.WriteLine();
                byte[] messageBody = Encoding.ASCII.GetBytes(payloadAsJson);
                IBasicProperties properties = channel.CreateBasicProperties();
                properties.ContentType = "text/plain";
                channel.BasicPublish("FirstRabbitMQExchange", "first", properties, messageBody);
                Console.WriteLine("Sent Data..");
            }



            //// now go and get the Message off the queue.
            //var consumer = new EventingBasicConsumer(channel);
            //consumer.Received += Consumer_Received;
            //channel.BasicConsume("FirstQueue", true, consumer);
            //Console.WriteLine("Completed Reading all messages in queue.");
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var body = e.Body;
            var message = Encoding.ASCII.GetString(body);


            Payload  payload = JsonConvert.DeserializeObject<Payload>(message);
            Console.WriteLine($"Received : {payload.Created} {payload.Message}");
        }
    }


   
}
