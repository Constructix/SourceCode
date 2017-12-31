using System.Configuration;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class TokenController : ApiController
    {
        private string Token => ConfigurationManager.AppSettings["token"];

        protected TokenController()
        {
        }
        [Route("api/Token")]
        [HttpGet]
        public string Get()
        {
            return Token;
        }
    }
}