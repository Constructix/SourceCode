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
            "Endpoint=sb://constructix-svc-bsns-suppliers.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=e5cyQ7s3t0kwEaaEpCGFGSyllXP3qCE5agWhPUwm3M4=";
        private const string QueueName = "suppliers";
        static async Task Main(string[] args)
        {
            const int StartOrderIndex = 0;
            const int TotalOrders = 60;
            Console.WriteLine($"Sending total: {TotalOrders} to {QueueName}");
            await using (ServiceBusClient svcBusClient = new ServiceBusClient(ServiceBusConnectionString))
            {
                for (int i = StartOrderIndex; i < TotalOrders; i++)
                {
                    var order = new Order { 
                                            Created = DateTime.Now, 
                                            Id =  Guid.NewGuid()
                                            };

                    ServiceBusSender sender = svcBusClient.CreateSender(QueueName);
                    ServiceBusMessage msg = new ServiceBusMessage(Order.ToJson(order));

                    await sender.SendMessageAsync(msg);
                    Console.WriteLine($"Sending Order[{i+1}] Id: {order.Id}");
                }
            }

            Console.WriteLine($"Completed sending {TotalOrders} orders.");
        }

    }

   
}
