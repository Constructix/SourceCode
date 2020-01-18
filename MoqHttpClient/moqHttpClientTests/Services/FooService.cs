using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using moqHttpClientTests.Models;
using Newtonsoft.Json;

namespace moqHttpClientTests.Services
{
    public class FooService : IFooService
    {
        private HttpClient HttpClient { get;  }
        private IConfigurationRoot Configuration { get; }


        public FooService(HttpClient httpClient)
        {
            HttpClient = httpClient;
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Environment.CurrentDirectory)
                .AddJsonFile("appSettings.json")
                .Build();
            var config = new EndPointConfiguration();
        }

        public async Task<List<Order>> GetOrders()
        {
            HttpClient.BaseAddress = new Uri(Configuration["ServerAddress"]);
            var content = await HttpClient.GetAsync(Configuration["productsWebMethod"]);
            var orders = JsonConvert.DeserializeObject<List<Order>>(await content.Content.ReadAsStringAsync());
            if (orders != null)
                return orders;
            else
            {
                throw new Exception("Order Service could not retrieve orders.");
            }

        }
    }
}