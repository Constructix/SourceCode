using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GetSectionFromAppSettingsJsonDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICEClientSenderController : ControllerBase
    {

        [HttpPost]
        [Route("[action]")]
        public ActionResult<string> submitQuery([FromBody] SubmitQueryRequest queryRequest)
        {
            return "OK";
        }
    }

    public class SubmitQueryRequest
    {
        public string Value { get; set; }
    }
}