using System;
using System.Threading.Tasks;
using AzureFunctions.Data;
using RestSharp;

namespace AZ_Func_ConstructixConvertToUpperCase_V2_Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // calling Azure functions


            Console.WriteLine("Calling Azure Function.......");


            RestClient client = new RestClient(@"http://localhost:7071/api");
            var request = new RestRequest("UpperCaseFunction", DataFormat.Json).AddJsonBody(new UpperCaseRequest { Message = "Hello" });
            var response = await client.PostAsync<UpperCaseResponse>(request);


            Console.WriteLine($"Message: {response.Message}");
            Console.WriteLine($"Response Created: {response.Created}");

        }
    }
}
