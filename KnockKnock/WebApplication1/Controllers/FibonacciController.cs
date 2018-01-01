using System.Threading.Tasks;
using System.Web.Http;
using Services;

namespace KnockKnock.Controllers
{
    public class FibonacciController : ApiController
    {

        [HttpGet]
        /// <summary>
        /// Returns the nth number in the fibonacci sequence.
        /// </summary>
        /// <param name="n">The index(n) of the fibonacci sequence.</param>
        /// <returns></returns>
        public long Get(long n)
        {
            var t = Task<long>.Factory.StartNew(() =>
            {
                long f1 = 0;
                long f2 = 1;
                long result = 0;
                for (long index = 0; index < n; index++)
                {
                    result = f1 + f2;
                    f2 = f1;
                    f1 = result;

                }
                return result;
            });
            return t.Result;
        }
    }
}