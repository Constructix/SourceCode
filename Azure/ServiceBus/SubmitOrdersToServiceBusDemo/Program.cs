using System;
using System.Text;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using OrdersDomain;

namespace SubmitOrdersToServiceBusDemo
{
    class Program
    {
        private const string ServiceBusConnectionString =
            "Endpoint=sb://ordersqueue.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=KdrsC5sFmQmc6y3Erbx1DdBZtzmoSNcQkVsgZXA0irI=";
        private const string QueueName = "orders";
        static async Task Main(string[] args)
        {

            
            const int totalOrders = 10;
            Console.WriteLine($"Sending total: {totalOrders} to {QueueName}");
            await using (ServiceBusClient svcBusClient = new ServiceBusClient(ServiceBusConnectionString))
            {
                for (int i = 0; i < 10; i++)
                {
                    var order = new Order();

                    ServiceBusSender sender = svcBusClient.CreateSender(QueueName);
                    ServiceBusMessage msg = new ServiceBusMessage(Order.ToJson(order));

                    await sender.SendMessageAsync(msg);
                    Console.WriteLine($"Sending Order[{i+1}] Id: {order.Id}");
                }
            }

            Console.WriteLine($"Completed sending {totalOrders} orders.");
        }

    }

   
}
