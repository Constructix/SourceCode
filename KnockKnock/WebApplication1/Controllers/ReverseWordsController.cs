using System.Text;
using System.Web.Http;
using Services;

namespace WebApplication1.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class ReverseWordsController : ApiController
    {
        private KnockKnockService _service;
        /// <summary>
        /// 
        /// </summary>
        public ReverseWordsController()
        {
            _service = new KnockKnockService();
        }
        /// <summary>
        /// Reverses the letters of each word in a sentence.
        /// </summary>
        /// <param name="sentence">A sentence</param>
        /// <returns></returns>
        [Route("api/ReverseWords")]
        [HttpGet]
        public string Get(string sentence)
        {
            return _service.ReverseStringsInSentence(sentence);
        }
    }
}