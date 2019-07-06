using System;
using System.Text;
using GetSectionFromAppSettingsJsonDemo.ConfigurationSettingsPOCO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GetSectionFromAppSettingsJsonDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ICEClientReceiverController : ControllerBase
    {

        public ICEClientReceiverController(IConfiguration configuration)
        {
            this._configuration = configuration;
            iceClientReceiver = this._configuration.GetSection("IceClientReceiver").Get<IceClientReceiver>();
        }

        private IConfiguration _configuration;
        private IceClientReceiver iceClientReceiver;
        [HttpPost]
        [Route("[action]")]
        public ActionResult<string> SubmitQuery(SubmitQueryRequest queryRequest)
        {
            StringBuilder builder  = new StringBuilder();
            builder.AppendLine("received request forwarding onto the FMS Client.");

            return builder.ToString();
        }

        [HttpGet]
        public ActionResult<IceClientReceiver> Get()
        {
            return iceClientReceiver;
        }
    }
}