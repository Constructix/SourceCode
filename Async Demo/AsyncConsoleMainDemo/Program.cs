using System;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AsyncConsoleMainDemo
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            //GetWebSites().GetAwaiter().GetResult();
            await GetWebSites();
        }


        private static async Task GetWebSites()
        {
            var webSites = new string[]
            {
                "http://www.constructix.com.au", 
                "http://www.bing.com", 
                "http://oracle.com"
            };


            foreach (string webSite in webSites)
            {
                var result = await GetResults(webSite);
                Console.WriteLine(result.Length);
            }

        }

        public static async Task<string> GetResults(string webAddress)
        {
            var result = await new HttpClient().GetStringAsync(webAddress);

            return result;
        }
    }
}
