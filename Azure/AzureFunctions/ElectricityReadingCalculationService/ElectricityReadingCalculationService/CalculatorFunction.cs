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
                ReadingRequest request =  JsonConvert.DeserializeObject<ReadingRequest>(data);
                log.Info($"Reading request received.{ DateTime.Now.ToUniversalTime()}");

                TimeSpan totalDays  = new TimeSpan();
                Status status = Status.Ok;
                int totalUsage = Reading.TotalUsage(request.FirstReading, request.LastReading);
                if (totalUsage <0) 
                    status = Status.UsageError;
                else
                {
                    totalDays = Reading.TotalDays(request.FirstReading, request.LastReading);
                    if (totalDays.Days <0 ) 
                        status = Status.DateTimeError;
                }
                HttpResponseMessage httpResponseMessage =null;
                switch (status)
                {
                    case Status.Ok:
                         httpResponseMessage =  req.CreateResponse(HttpStatusCode.OK, new ReadingResponse(totalUsage, totalDays, "Successfully completed calculation."));                      
                        break;
                    case Status.UsageError:
                        httpResponseMessage =  req.CreateErrorResponse(HttpStatusCode.BadRequest,"First Reading cannot be greater than the last reading.");
                        break;
                    case Status.DateTimeError:
                        httpResponseMessage =  req.CreateErrorResponse(HttpStatusCode.BadRequest,"First Reading DateTime cannot be greater than the last reading.");                    
                        break;
                }
                return httpResponseMessage;
            }
            catch (Exception ex)
            {
                throw;
            }            
        }
    }    

    public enum Status
    {
        Ok,
        UsageError,
        DateTimeError
    }

    public class ReadingRequest
    {
        public Reading FirstReading {get;set;}
        public Reading LastReading {get;set;}

        public ReadingRequest() { }
        public ReadingRequest(Reading firstReading, Reading lastReading)
        {
            this.FirstReading = firstReading;
            this.LastReading = lastReading;
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


        public static int TotalUsage(Reading firstReading, Reading lastReading)
        {

            if(firstReading.Value > lastReading.Value)
                return -1;
            return lastReading.Value  - firstReading.Value;
        }

        internal static TimeSpan TotalDays(Reading firstReading, Reading lastReading)
        {
            return lastReading.Recorded.Subtract(firstReading.Recorded.Date);            
        }
    }

    public class ReadingResponse
    {
        public int TotalUsage {get;set;}
        public int TotalDays {get;set;}
        public DateTime DateTimeStamp {get;set;}
        public string Message {get; }




        public ReadingResponse()
        {
            
            DateTimeStamp = DateTime.Now;
        }
         public ReadingResponse(int totalUsage, TimeSpan totalDays, string message) : this()
        {            
            this.TotalUsage = totalUsage;
            this.TotalDays = totalDays.Days;
            this.Message = message;
        }
    }  
}
