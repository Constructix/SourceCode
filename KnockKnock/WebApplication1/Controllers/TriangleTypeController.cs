using System.Web.Http;
using Services;
using Triangle = KnockKnock.Models.Triangle;

namespace KnockKnock.Controllers
{
    public class TriangleTypeController : ApiController
    {
        

        /// <summary>
        /// Returns the type of triange given the lengths of its sides
        /// </summary>
        /// <param name="a">The length of side a</param>
        /// <param name="b">The length of side b</param>
        /// <param name="c">The length of side c</param>
        /// <returns></returns>
        [Route("api/TriangleType")]
        [HttpGet]
        public string Get(int a, int b, int c)
        {

            Triangle inputTriangle = new Triangle(a,b,c);
            return Triangle.TriangleType(inputTriangle);
        }
    }

    
}