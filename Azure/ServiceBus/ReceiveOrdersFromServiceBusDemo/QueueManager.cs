using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Serilog;

namespace ReceiveOrdersFromServiceBusDemo
{
    //public class QueueManager
    //{
    //    #region privates
    //    //private MessageHandlerOptions messageHandlerOptions;
    //    //private static IQueueClient _queueClient;
    //    #endregion

    //    public string QueueName { get; set; }
    //    public string ServiceBusConnection { get; set; }       

    //    private QueueManager()
    //    {
           
    //    }

    //    public QueueManager(string serviceBusConnection, string queueName)
    //    {
    //       ServiceBusConnection = serviceBusConnection;
    //       QueueName = queueName;
    //       SetupMessageHandling();
    //    }

    //    //private void SetupMessageHandling()
    //    //{
    //    //    //setup messageHandlerOptions
    //    //    messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler);
    //    //    _queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
    //    //}

    //    public async Task ProcessMessagesAsync(Message message, CancellationToken token)
    //    {
    //        var messageBody = Encoding.UTF8.GetString(message.Body);
    //        Log.Information(messageBody);
    //        // Process the message.
    //        Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{messageBody}");
    //        ///////////////////////////////////////////////////////////////////////////////////////////////////////
    //        // write to log file...
    //        // Complete the message so that it is not received again.
    //        // This can be done only if the queue Client is created in ReceiveMode.PeekLock mode (which is the default).
    //        await _queueClient.CompleteAsync(message.SystemProperties.LockToken);

    //        // Note: Use the cancellationToken passed as necessary to determine if the queueClient has already been closed.
    //        // If queueClient has already been closed, you can choose to not call CompleteAsync() or AbandonAsync() etc.
    //        // to avoid unnecessary exceptions.
    //    }

    //    private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
    //    {
    //        Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
    //        var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
    //        Console.WriteLine("Exception context for troubleshooting:");
    //        Console.WriteLine($"- Endpoint: {context.Endpoint}");
    //        Console.WriteLine($"- Entity Path: {context.EntityPath}");
    //        Console.WriteLine($"- Executing Action: {context.Action}");
    //        return Task.CompletedTask;
    //    }
    //}
}
