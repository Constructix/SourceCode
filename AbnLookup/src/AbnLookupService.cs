using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using AbnLookup.ResponseEntities;
using Microsoft.Extensions.Configuration;

namespace AbnLookup
{
    public class AbnLookupService : IAbnLookupService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        private const string Response = "Response";

        public AbnLookupService(HttpClient client, IConfiguration configuration)
        {
            this.httpClient = client;
            this._configuration = configuration;
        }

        public async Task<NameLookupResponse> NameLookup(NameLookupRequest request)
        {
            
            var response = await httpClient.GetStringAsync(
                $@"{_configuration["NameLookupURL"]}?name={request.NameOfEntity}&maxResults={request.MaxResultsToReturn}&callback={Response}&guid={_configuration["ApiKey"]}");
            

            var responseBuilder = CleanUpResponseObject(response, Response);

            return JsonSerializer.Deserialize<NameLookupResponse>(responseBuilder.ToString());
        }

        private static StringBuilder CleanUpResponseObject(string response, string Response)
        {
            StringBuilder responseBuilder = new StringBuilder(response);
            responseBuilder.Remove(0, Response.Length + 1);
            responseBuilder.Remove(responseBuilder.Length - 1, 1);
            return responseBuilder;
        }
    }
}