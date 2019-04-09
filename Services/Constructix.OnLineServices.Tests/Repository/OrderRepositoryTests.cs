using Constructix.OnLineServices.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Constructix.OnlineServices.Data;
using Constructix.OnLineServices.DTO;
using Constructix.OnLineServices.Services;
using Constructix.OnLineServices.Tests.Contexts;
using Constructix.OnLineServices.Tests.Repository;
using Newtonsoft.Json;
using NSubstitute;
using Xunit;
using Shouldly;


namespace Constructix.OnLineServices.Tests.Services
{
    public class OrderRepositoryTests
    {
        private readonly GenericRepositoryTests _genericRepositoryTests = new GenericRepositoryTests();
        private readonly AwsContextTests AwsContextTests = new AwsContextTests();

        [Fact]
        public void OrderServiceInstanceCreatedNoExceptionExpected()
        {
            var ordersList = new List<Order>
            {
                new Order {Id = Guid.NewGuid(), CreateDateTime = DateTime.Now, LastUpdated = DateTime.Now}
            };
            var ordersRepository = Substitute.For<IRepository<Order>>();
            ordersRepository.GetAll().Returns(ordersList);
            IService<Order> orderService = new OrderService(ordersRepository);
            orderService.GetAll().Any().ShouldNotBe(false);
        }

        [Fact]
        public void AddNewOrderToRepositoryAndRetrieveId()
        {
            const string guidAsString = "5cead34c-f83e-4f27-bc5e-be9d0f120687";
            var testGuid = Guid.Empty;

            Guid.TryParse(guidAsString, out testGuid);
            var ordersList = new List<Order>
            {
                new Order {Id = Guid.NewGuid(), CreateDateTime = DateTime.Now, LastUpdated = DateTime.Now},
                new Order {Id = testGuid, CreateDateTime = DateTime.Now, LastUpdated = DateTime.Now}
            };

            var ordersRepository = Substitute.For<IRepository<Order>>();
            ordersRepository.Get(testGuid).Returns(ordersList[1]);
            IService<Order> orderService = new OrderService(ordersRepository);
            orderService.Get(testGuid).ShouldNotBe(null);

        }


        [Fact]
        public async Task CreateDynamoDBClient()
        {
        //    AmazonDynamoDBConfig config = new AmazonDynamoDBConfig {ServiceURL = "http://localhost:8000"};
        //    IAmazonDynamoDB client = new AmazonDynamoDBClient(config);
        //    DynamoDBContext context = new DynamoDBContext(client);

        //    var testGuid = "8acd2b55-64c2-4917-a857-3fb550b12ae9";
        //    var newOrderId = Guid.Empty;
        //    Guid.TryParse(testGuid, out newOrderId);
            
        //    //var db = await context.LoadAsync<DynamoOrder>(newOrderId, "master");
        //    //if (db != null)
        //    //    await context.DeleteAsync<DynamoOrder>(db);
        //    // Query
        //    var orders = await GetOrdersThatMatchGuid(context, newOrderId);
        //    var deleteBatch = context.CreateBatchWrite<DynamoOrder>();
        //    deleteBatch.AddPutItems(orders.AsEnumerable());
        //    await deleteBatch.ExecuteAsync();



        //    // create Order
        //    var order = new Order(newOrderId, DateTime.Now, DateTime.Now);
        //    var dbOrder = new DynamoOrder(order.Id, "master", JsonConvert.SerializeObject(order), string.Empty);
        //    var dbOrderStatus = new DynamoOrder(order.Id,"status", JsonConvert.SerializeObject(new OrderStatus { OrderId = order.Id}), "-1");

        //    var batchConfig = new DynamoDBOperationConfig();
        //    batchConfig.SkipVersionCheck = false;
        //    var orderBatch = context.CreateBatchWrite<DynamoOrder>(batchConfig);

        //    for (int i = 0; i < 50; i++)
        //    {
        //        var dbOrderLineItem = new DynamoOrder(order.Id,i.ToString() , JsonConvert.SerializeObject(new OrderLine{LineOrderNumber = i,
        //            OrderId = order.Id }), string.Empty);

        //        orderBatch.AddPutItem(dbOrderLineItem);
        //    }

        //    orderBatch.AddPutItem(dbOrder);
        //    orderBatch.AddPutItem(dbOrderStatus);

        //    await orderBatch.ExecuteAsync();


        //    //await context.SaveAsync(dbOrder);
        //    // Query
        //    AsyncSearch<DynamoOrder>  result = context.QueryAsync<DynamoOrder>(newOrderId);
        //    orders = new List<DynamoOrder>();
        //    orders.AddRange(await result.GetRemainingAsync());
        //    while (!result.IsDone)
        //    {
        //        orders.AddRange(await result.GetRemainingAsync());
        //    }
        //    var number = orders.Count;

        //    // load method

        //    var dynamoOrder = await context.LoadAsync<DynamoOrder>(newOrderId, "master");

        //    dynamoOrder.ShouldNotBeNull();
        //}

        //private static async Task<List<DynamoOrder>> GetOrdersThatMatchGuid(DynamoDBContext context, Guid newOrderId)
        //{
        //    AsyncSearch<DynamoOrder> result = context.QueryAsync<DynamoOrder>(newOrderId);
        //    List<DynamoOrder> orders = new List<DynamoOrder>();
        //    orders.AddRange(await result.GetRemainingAsync());
        //    while (!result.IsDone)
        //    {
        //        orders.AddRange(await result.GetRemainingAsync());
        //    }

        //    return orders;
        }
    }
}
