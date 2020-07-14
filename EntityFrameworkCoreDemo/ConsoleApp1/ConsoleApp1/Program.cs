using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void  Main(string[] args)
        {
            

            HttpClient client = new HttpClient();


            var productAgreements = new List<ProductAgreementResponse>();


            for (int i = 0; i < 10; i++)

            {
                productAgreements.Add( new ProductAgreementResponse() { Id  = i + 1});
            }

         
            Parallel.ForEach(productAgreements, async (currentProductAgreement) =>
            {
                await GetDataTest(client, currentProductAgreement);
            });

            Console.WriteLine("Awaiting processing.....");
            Task.WaitAll();
            Console.WriteLine("Press Any Key to continue.");

            Console.ReadKey();

            
        }

        private static  async Task GetDataTest(HttpClient client, ProductAgreementResponse currentProductAgreement)
        {
            Console.WriteLine($"Processing: {currentProductAgreement.Id}");
            var response = await client.GetAsync("http://www.constructix.com.au");
            if (response.IsSuccessStatusCode)
            {
                var contents = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Downloaded constructix data.. Length :{contents.Length}");
            }
        }
    }

    public class ProductAgreementResponse
    {
        public int Id { get; set; }
    }
}
