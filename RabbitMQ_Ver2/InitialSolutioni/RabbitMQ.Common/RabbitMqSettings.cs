using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQ.Common
{
    public static class RabbitMqSettings
    {
        public const string RabbitServerUrl = @"amqp:/guest:guest@localhost:15672/";
        public const string ExchangeName = "FirstRabbitMQExchange";
        public const string QueueName= "FirstQueue";
        public const string RoutingKeyName = "first";
    }
}
