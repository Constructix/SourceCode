using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Newtonsoft.Json;
using Xunit;

namespace GetResponseFromOrderAPI.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void mTest1()
        {
            HttpClient client = new HttpClient();


            HttpRequestMessage requestMessage = new HttpRequestMessage(HttpMethod.Post, "http://localhost/ASPNetCore/api/order");
            requestMessage.Content = new StringContent(new OrderRquest(Guid.NewGuid(), DateTime.Now).ToJson(), Encoding.UTF8, "application/json" );

            var response = client.SendAsync(requestMessage);


            var content = response.Result.Content.ReadAsStringAsync().Result;

            var status = response.Result.StatusCode;


        }
    }

    public class OrderResponse
    {

        public OrderRquest Request { get; set; }
        public Guid ResponseId { get; set; }
        public DateTime DateTimeStamp { get; set; }

        public OrderResponse()
        {
            
        }

        public OrderResponse(OrderRquest request, Guid responseId, DateTime dateTimeStamp)
        {
            Request = request;
            ResponseId = responseId;
            DateTimeStamp = dateTimeStamp;


            
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);

    }

    public class OrderRquest
    {
        public Guid Id { get; set; }
        public DateTime DateTimeStamp { get; set; }

        public OrderRquest()
        {
            
        }

        public OrderRquest(Guid id, DateTime dateTimeStamp)
        {
            Id = id;
            DateTimeStamp = dateTimeStamp;
        }

        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
    }
}
