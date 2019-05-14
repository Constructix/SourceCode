using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime.Internal.Util;
using Amazon.S3;
using Amazon.S3.Model;
using Newtonsoft.Json;

namespace S3Demo
{

    



    public class S3Data
    {
        public string TradingDay { get; set; }
        public string PaymentProvider { get; set; }
        public string OrderId { get; set; }
        public override string ToString()
        {
            return $"{TradingDay}/CyberSourcePayment/{OrderId.ToString()}";
        }
    }
    
    /// <summary>
    /// </summary>
    // DynamoDB



    class Program
    {
        static  async Task Main(string[] args)
        {
            // Create s3Bucket instance and add folder structure

            var s3Bucket = new S3Bucket<Order>(RegionEndpoint.APSoutheast2, "constructixtest");

            var newOrder = new OrderBuilder().Build();
            var tradingDay = DateTime.Today.ToString("yyyyMMdd");

            var testKey = $"{tradingDay}/CyberSourcePayment/{newOrder.Id.ToString()}";;
            var result = await s3Bucket.PutData(newOrder, testKey);
            



            // create region
            //var bucketRegion = Amazon.RegionEndpoint.APSoutheast2;
            //var client = new AmazonS3Client(bucketRegion);
            //try
            //{
            //    GetObjectRequest request = new GetObjectRequest
            //{
            //    BucketName = "constructixtest",
            //    Key = "e92204c8-6212-4550-9e3d-20341d369217"
            //};

            //    var responseBody = string.Empty;
            //    using (GetObjectResponse response = await client.GetObjectAsync(request))
            //    using (Stream streamReader = response.ResponseStream)
            //    using (StreamReader reader = new StreamReader(streamReader))
            //    {
            //        responseBody = reader.ReadToEnd();
            //        Order order = JsonConvert.DeserializeObject<Order>(responseBody);

            //        Console.WriteLine($"Serialised object: {responseBody}");
            //        Console.WriteLine($"Order Id: {order.Id}");

            //    }


            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}

            //var orderBuilder=  new OrderBuilder();
            //await WriteDataTosS3(orderBuilder, client);
        }

        private static async Task WriteDataTosS3(OrderBuilder orderBuilder, AmazonS3Client client)
        {


            var order = orderBuilder.Build();
            var clientObjectRequest = new PutObjectRequest
            {
                BucketName = "constructixtest",
                Key = order.Id.ToString(),
                ContentBody = JsonConvert.SerializeObject(orderBuilder.Build())
            };

            var putObjectResponse = await client.PutObjectAsync(clientObjectRequest);

            if (putObjectResponse.HttpStatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine("Order has been successfully added into s3 Bucket");
            }
            else
            {
                Console.WriteLine("New order has not be succesfully added.");
            }
        }
    }



    public class OrderBuilder
    {
        public Order Build()
        {
            return new Order(Guid.NewGuid(), DateTime.Now);
        }

        
    }

    public class S3Context
    {

        RegionEndpoint bucketRegion = Amazon.RegionEndpoint.APSoutheast2;
        private AmazonS3Client client = null;

        public S3Context()
        {
            client = new AmazonS3Client(bucketRegion);
        }
        public s3Entity<Order> Orders { get; set; }


        public  async Task Save(string bucketName)
        {
            foreach (Order currentOrder in Orders.ForEach())
            {
                var clientObjectRequest = new PutObjectRequest
                {
                    BucketName = "constructixtest",
                    Key = currentOrder.Id.ToString(),
                    ContentBody = JsonConvert.SerializeObject(currentOrder)


                };
                var putObjectResponse = await client.PutObjectAsync(clientObjectRequest);

            }

        }
        
    }


    public class s3Entity<T> where T : class
    {
        private List<T> items;

        public s3Entity()
        {
            items = new List<T>();
        }

        public IEnumerable<T> ForEach()
        {
            for (int i = 0; i < items.Count; i++)
            {
                yield return items[i];
            }
        }
        
        private T Item { get; set; }
    }



    public class Order
    {
        public Guid Id { get;  set; }
        public DateTime Created { get; set; }

        public Order()
        {
            
        }
        public Order(Guid id, DateTime created)
        {
            Id = id;
            Created = created;
        }

    }
}
