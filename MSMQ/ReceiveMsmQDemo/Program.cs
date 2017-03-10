using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using MSMQDemo.Common;
using Newtonsoft.Json;

namespace ReceiveMsmQDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            if (!MessageQueue.Exists(Settings.QueueName))
                MessageQueue.Create(Settings.QueueName);
            while (true)
            {
                try
                {
                    MessageQueue queue = new MessageQueue(Settings.QueueName);
                    Message currentMessage = queue.Receive(new TimeSpan(0,0,2));


                    byte[] contents = new byte[(int) currentMessage.BodyStream.Length];
                    int bytesRead = currentMessage.BodyStream.Read(contents, 0, (int) currentMessage.BodyStream.Length);
                    if (bytesRead == (int) currentMessage.BodyStream.Length)
                    {
                        var bodyAsString = ASCIIEncoding.ASCII.GetString(contents);
                        var newPayload = JsonConvert.DeserializeObject<Payload>(bodyAsString);

                        if (newPayload != null)
                        {
                            Console.WriteLine($"\t{newPayload.Created} {newPayload.Message}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Could not read body contents from messsage.");
                    }

                }
                catch (MessageQueueException msmqExc)
                {
                    if (msmqExc.MessageQueueErrorCode == MessageQueueErrorCode.IOTimeout)
                    {
                        Console.WriteLine("Queue is Empty.....");
                    }

                }
            }
        }
    }
}
