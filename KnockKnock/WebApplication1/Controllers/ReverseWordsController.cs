using System.Text;
using System.Web.Http;

namespace WebApplication1.Controllers
{
    public class ReverseWordsController : ApiController
    {
        [Route("api/ReverseWords")]
        [HttpGet]
        public string Get(string sentence)
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

            return sentenceBuilder.ToString();
        }
    }


    public class TriangleTypeController : ApiController
    {
      

        protected TriangleTypeController()
        {
        }

        [Route("api/TriangleType")]
        [HttpGet]
        public string Get(int a, int b, int c)
        {
            
            if (a == b && a == c && b == c)
            {
                
                return Constants.TriangleTypes.Equilateral;
            }
            else if (a == b || a == c || b == c)
                return Constants.TriangleTypes.Isosceles;
            else if (a != b || a != c || b != c)
                return Constants.TriangleTypes.Scalene;
            return Constants.TriangleTypes.Error;
        }
    }
}