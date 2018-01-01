using System.Text;
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
            return  ReverseStringsInSentence(sentence);
        }

        public string ReverseStringsInSentence(string sentence)
        {
            string[] words = sentence.Split(new char[] { ' ' });
            StringBuilder sentenceBuilder = new StringBuilder();

            foreach (var word in words)
            {
                for (int i = word.Length - 1; i >= 0; i--)
                {
                    sentenceBuilder.Append(word[i]);
                }
                sentenceBuilder.Append(" ");
            }
            sentenceBuilder.Remove(sentenceBuilder.Length - 1, 1);

            return sentenceBuilder.ToString().Trim();
        }
    }
}