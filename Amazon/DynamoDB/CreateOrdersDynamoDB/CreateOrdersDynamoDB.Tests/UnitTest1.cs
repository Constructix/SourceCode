using System;
using Amazon.DynamoDBv2;
using Amazon.Runtime.Internal.Util;
using Shouldly;
using Xunit;

namespace CreateOrdersDynamoDB.Tests
{
    public static class Constants
    {
        public static string LocalHost = "http://localhost:8000";
    }

    public class DynamoDBTests
    {
        private AmazonDynamoDBConfig config = new AmazonDynamoDBConfig();
        private AmazonDynamoDBClient client;

        public DynamoDBTests()
        {
            AmazonDynamoDBConfig config = new AmazonDynamoDBConfig();
            config.ServiceURL = Constants.LocalHost;
            client = new AmazonDynamoDBClient(config);
        }

        [Fact]
        public void CreateConnectionToLocalHostNoExceptionExpected()
        {
           AmazonDynamoDBConfig config = new AmazonDynamoDBConfig();
           config.ServiceURL = Constants.LocalHost;
           client.ShouldNotBeNull();
        }

        [Fact]
        public void CreateDatabase()
        {

        }
    }
}
