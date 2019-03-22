using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.DynamoDBv2.Model.Internal.MarshallTransformations;
using Newtonsoft.Json;

namespace CreateDynamoDBLocal
{

    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public List<ProductLineItems> LineItems { get; set; }

        public Order(Guid id, DateTime created)
        {
            Id = id;
            Created = created;
            LineItems = new List<ProductLineItems>();
        }

        public Order(Guid id, DateTime created, List<ProductLineItems> lineItems)
        {
            Id = id;
            Created = created;
            LineItems = lineItems;
        }

        public string ToJson() => JsonConvert.SerializeObject(this);
    }

    public class ProductLineItems   
    {
        public int Number { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------- Demostration of running a dynamo DB locally ----------------------");


            if (DynamoDBIntro.Create(true))
            {
                var client = DynamoDBIntro.Client;

                Console.WriteLine("Checking for tables");
                // Checking to see if there are any tables in the current Database.


                if (!TablesExist(client))
                {
                    Console.WriteLine("No Tables exist. - Creating");

                    CreateTable(client);

                }
                else
                {
                    InsertIntoTable(client);
                }
            }

            bool TablesExist(AmazonDynamoDBClient client)
            {
                return  client.ListTablesAsync().Result.TableNames.Any();
            }


        }

        private static void InsertIntoTable(AmazonDynamoDBClient client)
        {

            Order order = new Order(Guid.NewGuid(), DateTime.Now, new List<ProductLineItems>());

            Table orderBasket = Table.LoadTable(client, "Basket-Orders");
            var orderDoc = new Document();

            orderDoc["Id"] = Guid.NewGuid().ToString();
            orderDoc["Body"] = order.ToJson();

            orderBasket.PutItemAsync(orderDoc);

        }

        private static void CreateTable(AmazonDynamoDBClient client)
        {
            CreateTableRequest createTableRequest = new CreateTableRequest
            {
                TableName = "Basket-Orders",
                AttributeDefinitions = new List<AttributeDefinition>
                {
                    new AttributeDefinition
                    {
                        AttributeName = "Id",
                        AttributeType = "S"
                    },
                    new AttributeDefinition
                    {
                        AttributeName = "Body",
                        AttributeType = "S"
                    }
                },
                KeySchema = new List<KeySchemaElement>
                {
                    new KeySchemaElement
                    {
                        AttributeName = "Id",
                        KeyType = KeyType.HASH
                    },
                    new KeySchemaElement
                    {
                        AttributeName = "Body",
                        KeyType = KeyType.RANGE
                    }
                },
                ProvisionedThroughput = new ProvisionedThroughput
                {
                    ReadCapacityUnits = 10,
                    WriteCapacityUnits = 5
                }
            };

            var createTableResponse = client.CreateTableAsync(createTableRequest).Result;
            Console.WriteLine(createTableResponse.HttpStatusCode);
        }
    }




    public static class DynamoDBIntro
    {
        public static AmazonDynamoDBClient Client { get; set; }


        public static bool Create(bool useDynamoDBLocal)
        {

            bool operationSucceeded = false;
            bool operationFailed = false;

            if (useDynamoDBLocal)
            {
            
                // First, check to see whether anyone is listening on the DynamoDB local port
                // (by default, this is port 8000, so if you are using a different port, modify this accordingly)
                bool localFound = false;
                try
                {
                    using (var tcp_client = new TcpClient())
                    {
                        var result = tcp_client.BeginConnect("localhost", 8000, null, null);
                        localFound = result.AsyncWaitHandle.WaitOne(3000); // Wait 3 seconds
                        tcp_client.EndConnect(result);
                    }
                }
                catch
                {
                    localFound = false;
                }
                if (!localFound)
                {
                    Console.WriteLine("\n      ERROR: DynamoDB Local does not appear to have been started..." +
                                      "\n        (checked port 8000)");
                    operationFailed = true;
                    return (false);
                }

                // If DynamoDB-Local does seem to be running, so create a client
                Console.WriteLine("  -- Setting up a DynamoDB-Local client (DynamoDB Local seems to be running)");
                AmazonDynamoDBConfig ddbConfig = new AmazonDynamoDBConfig();
                ddbConfig.ServiceURL = "http://localhost:8000";
                try { Client = new AmazonDynamoDBClient(ddbConfig); }
                catch (Exception ex)
                {
                    Console.WriteLine("     FAILED to create a DynamoDBLocal client; " + ex.Message);
                    operationFailed = true;
                    return false;
                }
            }

            else
            {
                try { Client = new AmazonDynamoDBClient(); }
                catch (Exception ex)
                {
                    Console.WriteLine("     FAILED to create a DynamoDB client; " + ex.Message);
                    operationFailed = true;
                }
            }
            operationSucceeded = true;
            return true;
        }
    }
}

