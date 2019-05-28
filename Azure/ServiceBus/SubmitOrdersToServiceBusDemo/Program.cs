using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using OrdersDomain;

namespace SubmitOrdersToServiceBusDemo
{
    class Program
    {
        private const string ServiceBusConnectionString = "Endpoint=sb://constructixonline.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=BE6Vf+1KKy4SuYgy0m2xG/iUkLuS8xFUVKOLQwjsTfM=";
        private const string QueueName = "ordersqueue";

        private static IQueueClient _queueClient;
        static async Task Main(string[] args)
        {

            _queueClient = new QueueClient(ServiceBusConnectionString,QueueName);


            Console.WriteLine(new string('-', 80));
            Console.WriteLine("Press <Enter> key to exit after sending messages.");
            Console.WriteLine(new string('-', 80));

            await SendMessagesAsync(40);
        }
        static async Task SendMessagesAsync(int numberOfMessages)
        {
            try
            {
                for (int index = 0; index < numberOfMessages; index++)
                {

                    var orderAsString = Order.ToJson(new Order());
                    Console.WriteLine($"Sending Message - {orderAsString}");
                    var message = new Message(Encoding.ASCII.GetBytes(orderAsString));
                    
                    await _queueClient.SendAsync(message);
                }

                await _queueClient.CloseAsync();
            }
            catch (Exception e)
            {
                
                Console.WriteLine($"{DateTime.Now} :: Exception : {e.Message}");
            }
          
        }
    }

   
}
