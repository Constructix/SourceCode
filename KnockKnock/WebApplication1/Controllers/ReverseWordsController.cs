using System.Web.Http;
using Services;

namespace KnockKnock.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ReverseWordsController : ApiController
    {
      
        /// <summary>
        /// Reverses the letters of each word in a sentence.
        /// </summary>
        /// <param name="sentence">A sentence</param>
        /// <returns></returns>
        [Route("api/ReverseWords")]
        [HttpGet]
        public string Get(string sentence)
        {
            return  KnockKnockService.Service.ReverseStringsInSentence(sentence);
        }
    }
}