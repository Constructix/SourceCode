using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Constructix.OnlineServices.Data.Contexts;
using Xunit;

namespace Constructix.OnLineServices.Tests.Contexts
{
    public class AwsContextTests
    {
        [Fact]
        public void CreateContexts()
        {
            // //////////////////////////////////////////////////////////////////////////////////////////////////
            // setup Dynamo
            // 1. Use local instance.
            // 2. Assign LocalClient to the oontext.

            AmazonDynamoDBConfig config = new AmazonDynamoDBConfig { ServiceURL = "http://localhost:8000" };
            IAmazonDynamoDB client = new AmazonDynamoDBClient(config);
            DynamoDBContext context = new DynamoDBContext(client);


            var awsContext =new AWSContext(context);
            var ordersContext = new OrdersContext();
            // can use entityframework.
            var entityFramework = new EntityFrameworkContext<OrdersContext>(ordersContext);

        }
    }
}