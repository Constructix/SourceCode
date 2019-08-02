using GetSectionFromAppSettingsJsonDemo.ConfigurationSettingsPOCO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GetSectionFromAppSettingsJsonDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IceEngineController : ControllerBase
    {
        private IConfiguration configuration;
        private IceEngine iceEngine;

        private IceClientReceiver iceClientReceiver;


        public IceEngineController(IConfiguration configuration)
        {
            this.configuration = configuration;
            iceEngine = new IceEngine();
            this.configuration.GetSection("IceEngine").Bind(iceEngine);

            //iceClientReceiver = this.configuration.GetSection("IceClientReceiver").Get<IceClientReceiver>();
            iceEngine = this.configuration.GetSection("IceEngine").Get<IceEngine>();

        }

        [HttpGet]

        public IceEngine Get()
        {
            return iceEngine;
        }
    }
}