using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AzureFunctions.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace AZ_Func_ConstructixConvertToUpperCase_V2
{
    public static class UpperCaseFunction
    {
        [FunctionName("UpperCaseFunction")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)]
            HttpRequest request,
            ILogger log)
        {

            request.Headers.TryGetValue("X-Forwarded-For", out StringValues values);

            if (values.ToArray().Any())
            {
                var value = values.First();
            }

            log.LogInformation("UpperCaseFunction has been called.");

            string requestBody = await new StreamReader(request.Body).ReadToEndAsync();
            var upperCaseRequest = JsonConvert.DeserializeObject<UpperCaseRequest>(requestBody);
            var upperCaseResponse = new UpperCaseResponse() { Message = upperCaseRequest.Message.ToUpper(), Created = DateTimeOffset.Now, Values = values.ToList() };

            return new OkObjectResult(upperCaseResponse);

        }
    }
}
