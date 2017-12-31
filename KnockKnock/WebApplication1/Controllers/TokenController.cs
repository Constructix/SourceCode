using System.Web.Http;
using Services;

namespace KnockKnock.Controllers
{
    public class TokenController : ApiController
    {
      
        /// <summary>
        /// Your token.
        /// </summary>
        /// <returns></returns>
        [Route("api/Token")]
        [HttpGet]
        public string Get()
        {
            return  KnockKnockService.Service.Token;
        }
    }
}