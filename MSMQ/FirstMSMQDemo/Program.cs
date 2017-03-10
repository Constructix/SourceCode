using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using MSMQDemo.Common;
using Newtonsoft.Json;

namespace FirstMSMQDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            Payload payload = new Payload {Created = DateTime.Now, Message = "This is a test"};


            if (!MessageQueue.Exists(Settings.QueueName))
                MessageQueue.Create(Settings.QueueName);



            MessageQueue queue = new MessageQueue(Settings.QueueName);
            Message message = new Message();
            var payloadAsJson = JsonConvert.SerializeObject(payload);
            message.BodyStream = new MemoryStream(ASCIIEncoding.ASCII.GetBytes(payloadAsJson));
            Console.WriteLine("Message has been sent");
            queue.Send(message);
           
            
           
        }


    }

    public class QueueManager
    {
        public string QueueName { get; private set; }

        public QueueManager()
        {
            
        }

        public QueueManager(string queueName)
        {
            this.QueueName = queueName;
        }

        public void Send(Payload payload)
        {
            if (string.IsNullOrWhiteSpace(QueueName))
                throw new  Exception("Queue name has not be specified. To enable sending of messages, please specify a queueName.");
            else
            {
                MessageQueue queue =new MessageQueue(this.QueueName);
                var jsonPayload = ConvertPayloadIntoJson(payload);
                Message message = new Message();

            }
        }

        private string ConvertPayloadIntoJson(Payload payload)
        {
            return JsonConvert.SerializeObject(payload);
        }
    }


   
}
