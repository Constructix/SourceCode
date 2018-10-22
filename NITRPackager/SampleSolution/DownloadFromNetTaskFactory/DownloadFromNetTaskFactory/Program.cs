using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DownloadFromNetTaskFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] addresses = new string[] { "http://www.constructix.com.au", 
                                                "http://www.oracle.com", 
                                                "http://www.ibm.com",
                                                "http://www.stackoverflow.com", "http://www.cnet.com", "http://wwww.zdnet.com"};

            Stopwatch watch = new Stopwatch();

            watch.Start();
            for (int index = 0; index < addresses.Length; index++)
            {
                WebRequest webClient = HttpWebRequest.Create(new Uri(addresses[index]));
                WebResponse response = webClient.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    var contents = reader.ReadToEnd();

                    Console.WriteLine($"Length : {response.ContentLength}");
                }
            }

            watch.Stop();
            Console.WriteLine($"Time taken to download data : {watch.Elapsed.TotalMilliseconds}");


            watch.Reset();
            watch.Start();
            const string StringLengthHeader = "String Length";
            const string TaskIdHeader = "Task Id";
            Console.WriteLine($"{StringLengthHeader, 15}{TaskIdHeader,10}");
            Console.WriteLine(new string('-',50));
            addresses.AsParallel().ForAll(x =>
            {
                var t = DownloadDataAsync(x);
                Console.WriteLine($"{t.Result.Length, 15}{t.Id, 10}");
            });
            watch.Stop();
            Console.WriteLine($"Time taken to download data : {watch.Elapsed.TotalMilliseconds}");

            Task [] tasks  = new Task[addresses.Length];
            watch.Reset();
            watch.Start();
            
            for(int index = 0; index < addresses.Length; index++)
            {
                var index1 = index;
                tasks[index] =  Task.Factory.StartNew(() =>
                {
                    var currentTask = DownloadDataAsync(addresses[index1]);
               });
            }

           var final =  Task.Factory.ContinueWhenAll(tasks, completedTasks =>
            {
                watch.Stop();
                foreach (var completedTask in completedTasks)
                {
                    Console.WriteLine($"{completedTask.ToString()} {completedTask.Id,10}");
                } 
               
            });
            final.Wait();
            Console.WriteLine($"--------  Total Time Taken to download Data using TaskFactory: {watch.Elapsed.TotalMilliseconds}");
        }

       

        static async Task<string> DownloadDataAsync(string address)
        {
            var clientHandler = new HttpClientHandler
            {
                Proxy = new WebProxy(),
                
            };
            var client = new HttpClient(clientHandler);

            
            var currentTask = await client.GetStringAsync(address);
            return currentTask;
        }
    }
}
