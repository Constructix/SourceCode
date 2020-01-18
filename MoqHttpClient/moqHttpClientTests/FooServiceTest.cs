using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Moq;
using Moq.Contrib.HttpClient;
using Newtonsoft.Json;
using Shouldly;
using Xunit;

namespace moqHttpClientTests
{
    public class FooServiceTest
    {
        [Fact]
        public async Task ReturnProductList()
        {

            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appSettings.json").Build();
            
            var firstProductid = Guid.NewGuid();
            var firstProductCreated = DateTime.Parse("01/01/2020");
            var handler = new Mock<HttpMessageHandler>();

            var client = handler.CreateClient();
            client.BaseAddress = new Uri(configuration["ServerAddress"]);

            var productModel = new Product
            {
                Id = firstProductid,
                Created = firstProductCreated,
                EffectiveFrom = firstProductCreated.AddDays(-455)
            };

            List<Product> _productModels = new List<Product> { productModel};

            handler.SetupRequest(HttpMethod.Get, TestConstants.Products.ProductWebApiAddress)
                .ReturnsResponse(JsonConvert.SerializeObject(_productModels), "application/json").Verifiable();

            var fooService = new FooService(client);
            var orders = await fooService.GetOrders();
            handler.Verify();
            orders.ShouldNotBeNull();

            var product = orders.First();
            product.Id.ShouldBe(firstProductid);
        }
    }
}
