using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace AZ_FUNC_ConstructixConvertToUpperCaseConsoleClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Calling Azure Function.......");


            RestClient client = new RestClient(@"http://localhost:7071/api");
            var request = new RestRequest("UpperCaseFunction", DataFormat.Json).AddJsonBody(new UpperCaseRequest {Message = "Hello"});
            var response = await client.PostAsync<UpperCaseResponse>(request);


            Console.WriteLine($"Message: {response.Message}");
            Console.WriteLine($"Response Created: {response.Created}");


        }
    }


    public class UpperCaseRequest
    {
        public string Message { get; set; }
    }


    public class UpperCaseResponse
    {
        public string Message { get; set; }
        public DateTimeOffset Created { get; set; }
        public List<string> Values { get; set; }
    }
}
