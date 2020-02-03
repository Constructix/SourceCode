using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DeliverySerivce
{
    public static class SubmitDelivery
    {
        [FunctionName("SubmitDelivery")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            //log.LogInformation("C# HTTP trigger function processed a request.");
            log.LogInformation($"SubmitDelivery Function has been triggered.");


            var deliveryRequestAsString = await new StreamReader(req.Body).ReadToEndAsync();

            var deliveryRequest = JsonConvert.DeserializeObject<DeliveryRequest>(deliveryRequestAsString);

            return new OkObjectResult(new DeliveryResponse { Id = Guid.NewGuid(), ResponseDateTime = DateTime.Now, });



            //string name = req.Query["name"];

            //string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //dynamic data = JsonConvert.DeserializeObject(requestBody);
            //name = name ?? data?.name;

            //return name != null
            //    ? (ActionResult)new OkObjectResult($"Hello, {name}")
            //    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }

    public class DeliveryRequest
    {
        public string Status { get; set; }
        public DateTime ScheduledDeliveryTime { get; set; }
        public DateTime ScheduledPickupTime { get; set; }
        public Address DeliveryAddress { get; set; }
        public DeliveryRequest()
        {
            
        }
        public DeliveryRequest(string status, DateTime scheduledDeliveryTime, DateTime scheduledPickupTime, Address deliveryAddress)
        {
            this.Status = status;
            this.ScheduledDeliveryTime = scheduledDeliveryTime;
            this.ScheduledPickupTime = scheduledPickupTime;
            this.DeliveryAddress = deliveryAddress;
        }
    }

    public class Address
    {
        public string StreetNum { get; set; }
        public string Name { get; set; }
        public string Suburb { get; set; }
        public string Postcode { get; set; }
        public string State { get; set; }
    }

    public class DeliveryResponse
    {
        public DateTime ResponseDateTime { get; set; }

        public Guid Id { get; set; }


    }

}
