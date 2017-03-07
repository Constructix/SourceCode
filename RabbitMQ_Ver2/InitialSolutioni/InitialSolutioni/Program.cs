using System;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Common;

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
            channel.ExchangeDeclare(RabbitMqSettings.ExchangeName, ExchangeType.Direct);
            channel.QueueDeclare(RabbitMqSettings.QueueName, false, false, false, null);
            channel.QueueBind(RabbitMqSettings.QueueName, RabbitMqSettings.ExchangeName, RabbitMqSettings.RoutingKeyName, null);


            string[] firstNames = new  string[] {"Richard", "Shaun", "Grahame", "Bill", "Steve", "Edward", "Julian", "Tom", "Geoffrey","Clinton","Ian", "David", "Michael", "John", "Barry", "Scott"};
            string [] lastNames = new  string[] {"Jones", "Snowden", "Gilroy", "Jennings", "Smith", "Furry", "Dodds", "Huxley", "Williams", "Peters", "Jenkins" };

            Random r = new Random((int)DateTime.Now.Ticks);
            var orderFactory = new OrderFactory();
            for (int i = 0; i < 100; i++)
            {
                var order = CreateOrder(r, firstNames, lastNames, orderFactory);
                var payload = new Payload {Created = DateTime.Now,
                                            Message = "This is the payload Message",
                                            Order = order};
                var payloadAsJson = SerialisePayload(payload);

                Console.WriteLine(payloadAsJson);
                Console.WriteLine();
                byte[] messageBody = Encoding.ASCII.GetBytes(payloadAsJson);
                IBasicProperties properties = channel.CreateBasicProperties();
                properties.ContentType = "text/plain";
                channel.BasicPublish(RabbitMqSettings.ExchangeName, "first", properties, messageBody);
                Console.WriteLine("Sent Data..");
            }
        }

        private static Order CreateOrder(Random r, string[] firstNames, string[] lastNames, OrderFactory orderFactory)
        {
            int firstNameIndex = r.Next(0, firstNames.Length - 1);
            int lastNameNameIndex = r.Next(0, lastNames.Length - 1);
            var order = orderFactory.Create(new Customer
            {
                FirstName = firstNames[firstNameIndex],
                LastName = lastNames[lastNameNameIndex],
                Email = "Top@gmail.com"
            });
            return order;
        }

        private static string SerialisePayload(Payload payload)
        {
            // serialise the payload
            var payloadAsJson = JsonConvert.SerializeObject(payload);
            return payloadAsJson;
        }
    }
}
