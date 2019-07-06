using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace GetSectionFromAppSettingsJsonDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICEClientReceiverController : ControllerBase
    {

        [HttpPost]
        [Route("[action]")]
        public ActionResult<string> SubmitQuery(SubmitQueryRequest queryRequest)
        {
            StringBuilder builder  = new StringBuilder();
            builder.AppendLine("received request forwarding onto the FMS Client.");

            return builder.ToString();
        }
    }
}