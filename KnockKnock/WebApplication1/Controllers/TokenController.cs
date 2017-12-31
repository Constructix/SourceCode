using System.Configuration;
using System.Web.Http;
using Services;

namespace WebApplication1.Controllers
{
    public class TokenController : ApiController
    {

        KnockKnockService _service;

        public TokenController()
        {
            _service = new KnockKnockService();
        }
        
        /// <summary>
        /// Your token.
        /// </summary>
        /// <returns></returns>
        [Route("api/Token")]
        [HttpGet]
        public string Get()
        {
            return _service.Token;
        }
    }
}