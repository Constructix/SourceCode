using System;
using System.Text;
using FireOnWheels.Messaging;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace FireOnWheels.Registration.Web
{
    public class RabbitMqManager : IDisposable
    {
        private readonly IModel channel;

        public RabbitMqManager()
        {
            var connectionFactory = new ConnectionFactory {Uri = RabbitMqConstants.RabbitMqUri};
            var connection = connectionFactory.CreateConnection();
            channel = connection.CreateModel();
            connection.AutoClose = true;
        }

        public void SendRegisterOrderCommand(IRegisterOrderCommand command)
        {
            channel.ExchangeDeclare(exchange:RabbitMqConstants.RegisterOrderExchange, type:ExchangeType.Direct);
            channel.QueueDeclare(queue: RabbitMqConstants.RegisterOrderQueue, durable: false, exclusive: false, autoDelete: false, arguments: null);
            channel.QueueBind(queue: RabbitMqConstants.RegisterOrderQueue,exchange:RabbitMqConstants.RegisterOrderExchange, routingKey:"");


            var serialisedCommand = JsonConvert.SerializeObject(command);

            var messageProperites = channel.CreateBasicProperties();
            messageProperites.ContentType = RabbitMqConstants.JsonMimeType;
            channel.BasicPublish(exchange: RabbitMqConstants.RegisterOrderExchange, 
                                    routingKey:"", 
                                    basicProperties: messageProperites, 
                                    body: Encoding.ASCII.GetBytes(serialisedCommand));


        }





        public void Dispose()
        {
            if(channel.IsClosed)
                channel?.Dispose();
        }
    }

   
}