using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Amqp.Serialization;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace AzureServiceBusDemo
{
    class Program
    {
        private const string ServiceBusConnectionString = "Endpoint=sb://constructixonline.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=BE6Vf+1KKy4SuYgy0m2xG/iUkLuS8xFUVKOLQwjsTfM=";
        private const string QueueName = "ordersqueue";
        private static IQueueClient queueClient;

        private static  IConfiguration _configuration;
        
        static async Task Main(string[] args)
        {

            _configuration = new ConfigurationBuilder()
                                                .AddJsonFile("AppSettings.json", optional: true, reloadOnChange:true)
                                                .Build();

            
            Console.WriteLine($"Connection string: { _configuration["ServiceBusConnection"]}");
            Console.WriteLine(new string('-', 80));
            Console.WriteLine("Sending data to azure.");
            await MainAsync();
        }

        static async Task MainAsync()
        {
            const int numberOfMesasges = 10;

            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);
            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after sending all the messages.");
            Console.WriteLine("======================================================");

            await SendMessagesAsync(numberOfMesasges);
            Console.WriteLine("=======================================================");
            Console.WriteLine("  Messages have been successfully sent.");
            Console.WriteLine("=======================================================");
            Console.ReadKey();

            await queueClient.CloseAsync();


        }

        private static async Task SendMessagesAsync(int numberOfMesasges)
        {
            try
            {
                for (int index = 0; index < numberOfMesasges; index++)
                {
                    string messageBody = JsonConvert.SerializeObject(new Order {OrderItems = new List<OrderItem>(), Created = DateTime.Now, Id = Guid.NewGuid()});
                    var message   = new Message(Encoding.UTF8.GetBytes(messageBody));

                    Console.WriteLine($"Sending message [{index+1}]:{messageBody}");

                    await queueClient.SendAsync(message);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"{DateTime.Now} :: Exception : { exception.Message}");
            }


        }
    }


    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime Created { get;  set; }
        public List<OrderItem> OrderItems { get;  set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
        public Order(Guid id, DateTime created, List<OrderItem> orderItems)
        {
            Id = id;
            Created = created;
            OrderItems = orderItems;
        }

    }

    public class OrderItem
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }    
    }
}
