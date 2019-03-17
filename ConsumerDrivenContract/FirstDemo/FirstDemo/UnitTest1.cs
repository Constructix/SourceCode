using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PactNet;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using Xunit;

namespace FirstDemo
{
    public static class constants
    {
        public static  string globalID = "4FFE20D0-F759-4779-92D1-1D6D549B4BFD";
    }


    public class OrderResponse
    {
        public Guid EventId { get; set; }
        public DateTime DateTimeStamp { get; set; }
        public string Status { get; set; }

        public OrderResponse()
        {
            
        }

        public OrderResponse(Guid eventId, DateTime dateTimeStamp, string status)
        {
            EventId = eventId;
            DateTimeStamp = dateTimeStamp;
            Status = status;

        }

        public override string ToString()
        {
            return base.ToString();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    public class OrderRequest
    {
        public string Name { get; set; }
        public bool IsASAP { get; set; }

        public OrderRequest()
        {
            
        }

        public OrderRequest(string name, bool isAsap)
        {
            Name = name;
            IsASAP = isAsap;
        }

        public string ToJSon()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }



    public class SomethingApiClient
    {
        private readonly HttpClient _client;

        public SomethingApiClient(string baseUri = null)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseUri ?? "http://my-api") };
        }

        public OrderResponse GetOrderResponse(string id)
        {
            string reasonPhrase;

            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, $"{_client.BaseAddress}/api/getOrder");
            requestMessage.Content = new StringContent(new OrderRequest("First", true).ToJSon(), Encoding.UTF8, "application/json");

            var response = _client.SendAsync(requestMessage);
            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;

            if(status == HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<OrderResponse>(content);
            else
            {
                return null;
            }
        }

       
        private static void RaiseResponseError(HttpRequestMessage failedRequest, HttpResponseMessage failedResponse)
        {
            throw new HttpRequestException(
                String.Format("The Events API request for {0} {1} failed. Response Status: {2}, Response Body: {3}",
                    failedRequest.Method.ToString().ToUpperInvariant(),
                    failedRequest.RequestUri,
                    (int)failedResponse.StatusCode,
                    failedResponse.Content.ReadAsStringAsync().Result));
        }

        public void Dispose()
        {
            Dispose(_client);
        }

        public void Dispose(params IDisposable[] disposables)
        {
            foreach (var disposable in disposables.Where(d => d != null))
            {
                disposable.Dispose();
            }
        }
    }

    public class Something
    {
        public string id { get; set; }
    }

    public class ConsumerMyApiPact : IDisposable
    {
        public IPactBuilder PactBuilder { get; private set; }
        public IMockProviderService MockProviderService { get; private set; }

        public int MockServerPort { get { return 9222; } }
        public string MockProviderServiceBaseUri { get { return String.Format("http://localhost:{0}", MockServerPort); } }

        public ConsumerMyApiPact()
        {
            PactBuilder = new PactBuilder(); //Defaults to specification version 1.1.0, uses default directories. PactDir: ..\..\pacts and LogDir: ..\..\logs
                                             //or
            //PactBuilder = new PactBuilder(new PactConfig { SpecificationVersion = "2.0.0" }); //Configures the Specification Version
            //                                                                                  //or
            //PactBuilder = new PactBuilder(new PactConfig { PactDir = @"..\pacts", LogDir = @"c:\temp\logs" }); //Configures the PactDir and/or LogDir.

            PactBuilder
              .ServiceConsumer("Consumer")
              .HasPactWith("Something API");

            MockProviderService = PactBuilder.MockService(MockServerPort); //Configure the http mock server
                                                                           //or
            //MockProviderService = PactBuilder.MockService(MockServerPort, true); //By passing true as the second param, you can enabled SSL. A self signed SSL cert will be provisioned by default.
            //                                                                     //or
            //MockProviderService = PactBuilder.MockService(MockServerPort, true, sslCert: sslCert, sslKey: sslKey); //By passing true as the second param and an sslCert and sslKey, you can enabled SSL with a custom certificate. See "Using a Custom SSL Certificate" for more details.
            //                                                                                                       //or
            //MockProviderService = PactBuilder.MockService(MockServerPort, new JsonSerializerSettings()); //You can also change the default Json serialization settings using this overload    
            //                                                                                             //or
            //MockProviderService = PactBuilder.MockService(MockServerPort, host: IPAddress.Any); //By passing host as IPAddress.Any, the mock provider service will bind and listen on all ip addresses

        }

        public void Dispose()
        {
            PactBuilder.Build(); //NOTE: Will save the pact file once finished
        }
    }
    public class SomethingApiConsumerTests : IClassFixture<ConsumerMyApiPact>
    {
        private IMockProviderService _mockProviderService;
        private string _mockProviderServiceBaseUri;

        public SomethingApiConsumerTests(ConsumerMyApiPact data)
        {
            _mockProviderService = data.MockProviderService;
            _mockProviderService.ClearInteractions(); //NOTE: Clears any previously registered interactions before the test is run
            _mockProviderServiceBaseUri = data.MockProviderServiceBaseUri;
        }

        [Fact]
        public void PutSomething()
        {
            var expectedGuid = Guid.NewGuid();
            var testGuid = expectedGuid;
            // Arrange
            _mockProviderService.Given("Submitting Test Data that is in OrderRequest and getting pricing response")
                .UponReceiving("Order Request3, OrderResponse is to be returned.")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Post,
                    Path = "/api/getOrder",
                    Headers = new Dictionary<string, object>
                    {
                        {"Content-Type", "application/json; charset=utf-8"}
                    }

                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        {"Content-Type", "application/json; charset=utf-8"}
                    }
                    ,Body = new OrderResponse
                        {
                            EventId = testGuid, DateTimeStamp = DateTime.Now, Status = "OK"
                        }
                        .ToJson()
                });

            var consumer = new SomethingApiClient(_mockProviderServiceBaseUri);

            var result = consumer.GetOrderResponse("AA");


            Assert.Equal(expectedGuid, result.EventId);
            Assert.Equal("OK", result.Status);
        }

    }
        
}
