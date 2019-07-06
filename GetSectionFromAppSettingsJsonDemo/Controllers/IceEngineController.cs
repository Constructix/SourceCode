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

        public IceEngineController(IConfiguration configuration)
        {
            this.configuration = configuration;
            iceEngine = new IceEngine();
            this.configuration.GetSection("IceEngine").Bind(iceEngine);
        }

        [HttpGet]

        public IceEngine Get()
        {
            return iceEngine;
        }
    }
}