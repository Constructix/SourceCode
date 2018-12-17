using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace ElectricityReadingCalculationService
{

    public static class CalculatorFunction
    {
        [FunctionName("ReadingCalculator")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get","post", Route =null)]HttpRequestMessage req, TraceWriter log)
        {
            try
            {
                var  data = await req.Content.ReadAsStringAsync();
                Reading request = JsonConvert.DeserializeObject<Reading>(data);
                return req.CreateResponse(HttpStatusCode.OK, new ReadingResponse("Successfully completed calculation."));
            }
            catch (Exception ex)
            {


                throw;
            }
           
        }
    }    

    public class Reading
    {
        public int Value {get;set;}
        public DateTime Recorded  {get;set;}

        public Reading()
        {

        }

        public Reading(int value, DateTime recorded)
        {
            this.Value = value;
            this.Recorded = recorded;
        }
    }

    public class ReadingResponse
    {
        public DateTime DateTimeStamp {get;set;}
        public string Message {get; }

        public ReadingResponse()
        {
            DateTimeStamp = DateTime.Now;
        }
         public ReadingResponse(string message) : this()
        {            
            this.Message = message;
        }
    }


    //public static class CalculatorFunction
    //{
    //    [FunctionName("Function1")]
    //    public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
    //    {
    //        log.Info("C# HTTP trigger function processed a request.");

    //        // parse query parameter
    //        string name = req.GetQueryNameValuePairs()
    //            .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
    //            .Value;

    //        if (name == null)
    //        {
    //            // Get request body
    //            dynamic data = await req.Content.ReadAsAsync<object>();
    //            name = data?.name;
    //        }

    //        return name == null
    //            ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
    //            : req.CreateResponse(HttpStatusCode.OK, "Hello " + name);
    //    }
    //}
}
