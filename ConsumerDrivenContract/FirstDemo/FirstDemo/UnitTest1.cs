using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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


    public class SomethingApiClient
    {
        private readonly HttpClient _client;

        public SomethingApiClient(string baseUri = null)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseUri ?? "http://my-api") };
        }

        public Something GetSomething(string id)
        {
            string reasonPhrase;

            var request = new HttpRequestMessage(HttpMethod.Get, "/somethings/" + id);
            request.Headers.Add("Accept", "application/json");

            var response = _client.SendAsync(request);

            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;

            reasonPhrase = response.Result.ReasonPhrase; //NOTE: any Pact mock provider errors will be returned here and in the response body

            request.Dispose();
            response.Dispose();

            if (status == HttpStatusCode.OK)
            {
                return !String.IsNullOrEmpty(content) ?
                    JsonConvert.DeserializeObject<Something>(content)
                    : null;
            }

            throw new Exception(reasonPhrase);
        }

        public void PutSomething(string value)
        {
            var dateTime = DateTime.Now.ToString("O");
            var @event = new
            {
                EventId = constants.globalID,
                Timestamp = "11",
                EventType = "DetailsView"
            };

            var eventJson = JsonConvert.SerializeObject(@event, Formatting.Indented);
            var requestContent = new StringContent(eventJson, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, "/events") { Content = requestContent };

            var response = _client.SendAsync(request);

            try
            {
                var result = response.Result;
                var statusCode = result.StatusCode;
                if (statusCode == HttpStatusCode.Created)
                {
                    var okResponse = "OK";
                    Console.WriteLine(okResponse);
                }

                RaiseResponseError(request, result);
            }
            finally
            {
                Dispose(request, response);
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
            var id = Guid.NewGuid().ToString();
            _mockProviderService.UponReceiving("a request to create a new event")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Post,
                    Path = "/events",
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new
                    {
                        constants.globalID,
                        timestamp = "11",
                        eventType = "DetailsView"
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 201
                });

            var consumer = new SomethingApiClient(_mockProviderServiceBaseUri);

            //Act / Assert
            consumer.PutSomething("eventId");
        }



        [Fact]
        public void GetSomething_WhenTheTesterSomethingExists_ReturnsTheSomething()
        {


            
            //Arrange
            _mockProviderService
                .Given("There is a something with id 'tester'")
                .UponReceiving("A GET request to retrieve the something")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/somethings/tester",
                    Headers = new Dictionary<string, object>
                    {
                        { "Accept", "application/json" }
                    }
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new //NOTE: Note the case sensitivity here, the body will be serialised as per the casing defined
                    {
                        id = "tester",
                        firstName = "Totally",
                        lastName = "Awesome"
                    }
                }); //NOTE: WillRespondWith call must come last as it will register the interaction

            var consumer = new SomethingApiClient(_mockProviderServiceBaseUri);

            //Act
            var result = consumer.GetSomething("tester");

            

            //Assert
            Assert.Equal("tester", result.id);

            _mockProviderService.VerifyInteractions(); //NOTE: Verifies that interactions registered on the mock provider are called at least once
        }
    }
}
