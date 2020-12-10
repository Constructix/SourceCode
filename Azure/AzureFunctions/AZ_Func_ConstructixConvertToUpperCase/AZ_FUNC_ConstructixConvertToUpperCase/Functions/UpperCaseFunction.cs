using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AZ_FUNC_ConstructixConvertToUpperCase.Functions
{
    public static class UpperCaseFunction
    {
        [FunctionName("UpperCaseFunction")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
            HttpRequest request,
            ILogger log)
        {
            log.LogInformation("UpperCaseFunction has been called.");

            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            var upperCaseRequest = JsonConvert.DeserializeObject<UpperCaseRequest>(requestBody);
            var upperCaseResponse = new UpperCaseResponse() {Message = upperCaseRequest.Message.ToUpper(), Created =  DateTimeOffset.Now};

            return new OkObjectResult(upperCaseResponse);

        }
    }
}