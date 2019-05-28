using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;

namespace ReceiveOrdersFromServiceBusDemo
{


    class Program
    {





        private const string FileName = @"D:\Files\ReceiveOrders.txt";
        private const string ServiceBusConnectionString = "Endpoint=sb://constructixonline.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=BE6Vf+1KKy4SuYgy0m2xG/iUkLuS8xFUVKOLQwjsTfM=";
        private const string QueueName = "ordersqueue";

        private static IQueueClient _queueClient;
        static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().MinimumLevel.Information().WriteTo
                .RollingFile(FileName, LogEventLevel.Information)
                .CreateLogger();

            Log.Information("Reading ReceiveOrders has started.");

            _queueClient = new QueueClient(ServiceBusConnectionString, QueueName);


            Console.WriteLine(new String('-', 80));
            Console.WriteLine($"-- Reading from {QueueName}" );
            Console.WriteLine(new String('-', 80));

            
            Console.WriteLine("Press <Enter> key to exit after sending messages.");
            Console.WriteLine(new string('-', 80));
            await ReadMessagesAsync();
            Console.ReadLine();
            _queueClient.CloseAsync();
            Log.Information("Reading ReceiveOrders has Completed.");
        }

        private static async Task ReadMessagesAsync()
        {
           Console.WriteLine($"Retrieving from queue [{QueueName}].......");


           var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
           {
               MaxConcurrentCalls = 1,
               AutoComplete = false
           };
           _queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
        }

        private static async Task ProcessMessagesAsync(Message message, CancellationToken token)
        {

            var messageBody = Encoding.UTF8.GetString(message.Body);
            Log.Information(messageBody);
            // Process the message.
            Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{messageBody}");
            ///////////////////////////////////////////////////////////////////////////////////////////////////////
            // write to log file...
            // Complete the message so that it is not received again.
            // This can be done only if the queue Client is created in ReceiveMode.PeekLock mode (which is the default).
            await _queueClient.CompleteAsync(message.SystemProperties.LockToken);

            // Note: Use the cancellationToken passed as necessary to determine if the queueClient has already been closed.
            // If queueClient has already been closed, you can choose to not call CompleteAsync() or AbandonAsync() etc.
            // to avoid unnecessary exceptions.
        }

        private static Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
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
