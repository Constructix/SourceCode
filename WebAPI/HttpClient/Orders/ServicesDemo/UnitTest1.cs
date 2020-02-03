using System;
using System.Net.Http;
using System.Threading.Tasks;
using Ice.Client.Services;
using Newtonsoft.Json;
using Shouldly;
using WorldDomination.Net.Http;
using Xunit;

namespace ServicesDemo
{

    
    public class UnitTest1
    {
        public UnitTest1() { }

        [Fact]
        public void Test1()
        {
            HttpClient client = new HttpClient();
            IHeartBeatService svc = new HeartBeatService(client);
            var jurisdictionId = Guid.NewGuid();
            var heartBeatRequest = new HeartBeartRequest(jurisdictionId);
            var heartBeatResponse = svc.IsAlive(heartBeatRequest);
        }

        [Fact]
        public async Task Test_2()
        {

            HeartBeatResponse heartBeatResponse = new HeartBeatResponse() {IsAlive = true};

            var responseData = JsonConvert.SerializeObject(heartBeatResponse);
            var messageResponse = FakeHttpMessageHandler.GetStringHttpResponseMessage(responseData);

            var options = new HttpMessageOptions
            {
                RequestUri = "https://localhost:43000/api/recipient/CheckheartBeat",
                HttpResponseMessage = messageResponse
            };

            var messageHandler = new FakeHttpMessageHandler(options);
            HttpClient client = new HttpClient(messageHandler);
            IHeartBeatService svc = new HeartBeatService(client);
            var jurisdictionId = Guid.NewGuid();
            var heartBeatRequest = new HeartBeartRequest(jurisdictionId);
            var response = await svc.IsAlive(heartBeatRequest);
            response.IsAlive.ShouldBeTrue();
        }

        [Fact]
        public async Task NoConnectionToHeartBeat()
        {
            var expectedException = new HttpRequestException();
            var messageHandler =  new FakeHttpMessageHandler(expectedException);
            HttpClient client = new HttpClient(messageHandler);
            IHeartBeatService svc = new HeartBeatService(client);
            var jurisdictionId = Guid.NewGuid();
            var heartBeatRequest = new HeartBeartRequest(jurisdictionId);
            var heartBeatResponse =  await svc.IsAlive(heartBeatRequest);

            heartBeatResponse.IsAlive.ShouldBeFalse();
           
        }

    }

   
}
