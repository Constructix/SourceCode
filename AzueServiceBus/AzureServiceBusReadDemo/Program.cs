using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Newtonsoft.Json;
using Serilog;

namespace AzureServiceBusReadDemo
{
    class Program
    {

        private const string ServiceBusConnectionString = "Endpoint=sb://constructixonline.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=BE6Vf+1KKy4SuYgy0m2xG/iUkLuS8xFUVKOLQwjsTfM=";
        private const string QueueName = "ordersqueue";
        private static IQueueClient queueClient;

        static void Main(string[] args)
        {

            Log.Logger =  new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(@"c:\Files\AzureServiceBus.log", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Information($"[AzureReader] - Azure Reading Data.");
            Log.Information($"[AzureReader] - Reading data from QueueName: {QueueName}");
            MainAsync();
        }

        private static void MainAsync()
        {
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

            Console.WriteLine(new string('=', 80));
            Console.WriteLine($"Press ENTER key to exit after receiving all messages from {QueueName}");
            Console.WriteLine(new string('=', 80));

            RegisterOnMessageHandlerAndReceiveMessages();
            Console.ReadKey();
            queueClient.CloseAsync();
        }

        private static void RegisterOnMessageHandlerAndReceiveMessages()
        {
            var messageHandlerOptions = new MessageHandlerOptions (ExceptionReceivedHandler){ MaxConcurrentCalls = 1, AutoComplete = false};
            queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        private static async Task ProcessMessagesAsync(Message arg1, CancellationToken arg2)
        {

            Log.Information($"Received Message - SequenceNumber: {arg1.SystemProperties.SequenceNumber} - [Order] {Encoding.UTF8.GetString(arg1.Body)}");
            
            //Console.WriteLine($"Received Message - SequenceNumber: {arg1.SystemProperties.SequenceNumber} - {Encoding.UTF8.GetString(arg1.Body)}");
            await queueClient.CompleteAsync(arg1.SystemProperties.LockToken);
        }
        // Use this handler to examine the exceptions received on the message pump.
        static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
            Console.WriteLine("Exception context for troubleshooting:");
            Console.WriteLine($"- Endpoint: {context.Endpoint}");
            Console.WriteLine($"- Entity Path: {context.EntityPath}");
            Console.WriteLine($"- Executing Action: {context.Action}");
            return Task.CompletedTask;
        }
    }
}
