using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.Model.Internal.MarshallTransformations;
using Constructix.OnlineServices.Data.Contexts;
using Constructix.OnLineServices.Domain;
using Constructix.OnLineServices.DTO;
using Newtonsoft.Json;
using Xunit;

namespace Constructix.OnLineServices.Tests.Contexts
{
    public class AwsContextTests
    {
        [Fact]
        public async Task CreateContexts()
        {
            // //////////////////////////////////////////////////////////////////////////////////////////////////
            // setup Dynamo
            // 1. Use local instance.
            // 2. Assign LocalClient to the oontext.

            //AmazonDynamoDBConfig config = new AmazonDynamoDBConfig
            //{
            //    RegionEndpoint = RegionEndpoint.APSoutheast2
            //};

            IAmazonDynamoDB client = new AmazonDynamoDBClient(new AmazonDynamoDBConfig { RegionEndpoint = RegionEndpoint.APSoutheast2});
            DynamoDBContext context = new DynamoDBContext(client);


            for (int i = 0; i < 10; i++)
            {
                
                try
                {
                    var result = context.SaveAsync(CreateDynamoOrder());
                    result.

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

        }

        private DynamoOrder CreateDynamoOrder()
        {
            var order = new Order {Id = Guid.NewGuid(), CreateDateTime = DateTime.Now, LastUpdated = DateTime.Now};

            return new DynamoOrder(Guid.NewGuid(), 
                                  order.CreateDateTime, 
                                  JsonConvert.SerializeObject(order) );
        }

        [Fact]
        public async Task GetItems()
        {
            AmazonDynamoDBConfig config = new AmazonDynamoDBConfig { ServiceURL = "http://localhost:8000" };
            IAmazonDynamoDB client = new AmazonDynamoDBClient(config);
            DynamoDBContext context = new DynamoDBContext(client);
            ScanRequest scanRequest = new ScanRequest
           {
               TableName = "OnlineServicesOrders", ProjectionExpression = "Body"
           };
           var result = await client.ScanAsync(scanRequest);
           Assert.Equal(1, result.Count);
        }

    }


    [DynamoDBTable("OnlineServicesOrders")]
    public class DynamoOrder
    {
        [DynamoDBHashKey]
        public Guid Id { get; set; }
        [DynamoDBRangeKey]
        public DateTime Created { get; set; }

        [DynamoDBProperty]
        public string Body { get; set; }

        public DynamoOrder()
        {
            
        }
        public DynamoOrder(Guid id, DateTime created, string body)
        {
            Id = id;
            Created = created;
            Body = body;
        }

    }
}