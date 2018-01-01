using System.Web.Http;
using Services;

namespace KnockKnock.Controllers
{
    public class TokenController : ApiController
    {
        public string Token => "e789d4e2-fd2d-4ff7-b668-19f419186650";

        /// <summary>
        /// Your token.
        /// </summary>
        /// <returns></returns>
        [Route("api/Token")]
        [HttpGet]
        public string Get()
        {
            return  Token;
        }
    }
}