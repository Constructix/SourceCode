using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using AbnLookup.ResponseEntities;
using Microsoft.Extensions.Configuration;

namespace AbnLookup
{
    public class AbnLookup : IAbnLookup
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;

        public AbnLookup(HttpClient client, IConfiguration configuration)
        {
            this.httpClient = client;
            this._configuration = configuration;
        }

        public async Task<NameLookupResponse> NameLookup(NameLookupRequest request)
        {
            const string Response = "Response";
            var response = await httpClient.GetStringAsync(
                $@"{_configuration["NameLookupURL"]}?name={request.NameOfEntity}&maxResults={request.MaxResultsToReturn}&callback={Response}&guid={_configuration["ApiKey"]}");
            

            StringBuilder responseBuilder = new StringBuilder(response);
            responseBuilder.Remove(0, Response.Length + 1);
            responseBuilder.Remove(responseBuilder.Length - 1, 1);

            return  System.Text.Json.JsonSerializer.Deserialize<NameLookupResponse>(responseBuilder.ToString());
        }
    }
}