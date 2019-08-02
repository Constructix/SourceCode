using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using AspNetCore.Http.Extensions;
using Serilog;
using Serilog.Core;

namespace Ice.Client.Services
{
    public class HeartBeatService : IHeartBeatService
    {
        private HttpClient _httpClient;

        public HeartBeatService(HttpClient client)
        {
            _httpClient = client;
            Logger log = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File(@"D:\Serilog\Log.txt")
                .CreateLogger();
        }

        public async Task<HeartBeatResponse> IsAlive(HeartBeartRequest heartBeatRequest)
        {

            try
            {
                Log.Information($"[HeartBeat - IsAlive]");
                var response = await _httpClient.PostAsJsonAsync("https://localhost:43000/api/recipient/CheckheartBeat", heartBeatRequest);

                if (response.IsSuccessStatusCode)
                    return new HeartBeatResponse() { IsAlive = true };
                
            }
            catch (HttpRequestException )
            {
                // Now looping in three times to check if the service is up during that time.
                int counter = 0;
                Log.Information($"[HeartBeatCheck] - Attempting 3 times to check destination ICE Client can accept information.");
                while (counter < 2)
                {
                    Log.Information($"{counter+1}/3 attempts.");
                    Thread.Sleep(3000);
                    try
                    {
                        var response =
                            await _httpClient.PostAsJsonAsync("https://localhost:43000/api/recipient/CheckheartBeat",
                                heartBeatRequest);

                        if (response.IsSuccessStatusCode)
                            return new HeartBeatResponse() {IsAlive = true};
                       
                    }
                    catch (HttpRequestException)
                    {

                    }
                    counter++;
                }
            }
            Log.CloseAndFlush();
            return new HeartBeatResponse() { IsAlive = false };
           
        }
    }
}