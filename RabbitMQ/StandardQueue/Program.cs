using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace StandardQueue
{
    class Program
    {

        private static ConnectionFactory _factory;
        private static IConnection _connection;
        private static IModel _model;

        private const string QueueName = "Constructix_StandardQueue";


        static void Main(string[] args)
        {

            var payment1 = new Payment {AmountToPay = 25.0m, CardNumber = "1234123412341234", Name = "Mr S Haunts"};
            var payment2 = new Payment { AmountToPay = 5.0m, CardNumber = "1234123412341234", Name = "Mr S Haunts" };
            var payment3 = new Payment { AmountToPay = 2.0m, CardNumber = "1234123412341234", Name = "Mr S Haunts" };
            var payment4 = new Payment { AmountToPay = 179.0m, CardNumber = "1234123412341234", Name = "Mr S Haunts" };
            var payment5 = new Payment { AmountToPay = 235.0m, CardNumber = "1234123412341234", Name = "Mr S Haunts" };
            var payment6 = new Payment { AmountToPay = 895.0m, CardNumber = "1234123412341234", Name = "Mr S Haunts" };


            CreateQueue();

            SendMessage(payment1);
            SendMessage(payment2);
            SendMessage(payment3);
            SendMessage(payment4);
            SendMessage(payment5);
            SendMessage(payment6);

            Receive();
            Console.WriteLine("Data has been sent onto the queue....");
            Console.WriteLine("Press enter to end");

        }

        private static void Receive()
        {
            var consumer  = new EventingBasicConsumer(_model);
            consumer.Received += (_model, ea) =>
            {
                Payment message = JsonConvert.DeserializeObject<Payment>(Encoding.Default.GetString(ea.Body));
                Console.WriteLine($"------ Received {message.CardNumber} : {message.AmountToPay} : {message.Name}");
                Program._model.BasicAck(deliveryTag: ea.DeliveryTag, multiple:false );
            };
            Program._model.BasicConsume(queue: QueueName, noAck: true, consumer: consumer);
        }

      

        private static void SendMessage(Payment messagePayment)
        {
            _model.BasicPublish(string.Empty, QueueName, null, messagePayment.Serialize());
            Console.WriteLine($"[x] Payment Message Sent:{messagePayment.CardNumber} : {messagePayment.AmountToPay} : {messagePayment.Name}");
        }

        private static void CreateQueue()
        {
            _factory = new ConnectionFactory {HostName = "localhost", UserName = "guest", Password = "guest"};
            _connection = _factory.CreateConnection();
            _model = _connection.CreateModel();
            _model.QueueDeclare(QueueName, true, false, false, null);
        }
    }
}
