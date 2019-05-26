using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;

namespace ContextDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            AmazonDynamoDBConfig config = new AmazonDynamoDBConfig();
            config.ServiceURL = "http://localhost:8000";

            AmazonDynamoDBClient client = new AmazonDynamoDBClient(config);
           // DynamoDBContext context = new DynamoDBContext(client);
           var messageContext = new DynamoDBContext<Message, Guid>(client);
            

            var msg = new Message
                {Id = Guid.NewGuid(), Sent = DateTime.Now.ToUniversalTime().ToString(), Body = "Welcome to DynamoDB version 1"};


            var messageGuid = msg.Id;
            messageContext.SaveAsync(msg);


            var selectedMsg = await messageContext.Get(messageGuid);
            if (selectedMsg != null)
            {
                Console.WriteLine("Get function is working....");
                DateTime sentDateTimeAsDate = DateTime.Parse(selectedMsg.Sent);
                Console.WriteLine($"Sent Date: { sentDateTimeAsDate.ToLocalTime()}");
            }
        }
    }

    public interface IDynamoDBContext<T, K>
    {
        Task SaveAsync(T item);
        Task<T> Get(K key);

    }


    public class DynamoDBContext<T, K> : DynamoDBContext, IDynamoDBContext<T, K>
    {
        public DynamoDBContext(IAmazonDynamoDB client) : base(client)
        {
        }

        public DynamoDBContext(IAmazonDynamoDB client, DynamoDBContextConfig config) : base(client, config)
        {
        }

        public async Task SaveAsync(T item)
        {
           await base.SaveAsync(item);
        }

        public async Task<T> Get(K key)
        {
            return await base.LoadAsync<T>(key);
            
        }
    }

    [DynamoDBTable("Message")]
    public class Message
    {
        [DynamoDBHashKey] public Guid Id { get; set; }
        [DynamoDBRangeKey] public string Sent { get; set; }
        public string Body { get; set; }
    }
}
