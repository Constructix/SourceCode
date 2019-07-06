using GetSectionFromAppSettingsJsonDemo.ConfigurationSettingsPOCO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace GetSectionFromAppSettingsJsonDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FMSClientController : ControllerBase
    {
        private IConfiguration configuration;
        private FMSClient fmsClient;

        public FMSClientController(IConfiguration configuration)
        {
            this.configuration = configuration;
            fmsClient = new FMSClient();
            fmsClient = this.configuration.GetSection("FMSClient").Get<FMSClient>();
        }

        [HttpGet]

        public FMSClient Get()
        {
            return fmsClient;
        }
    }
}