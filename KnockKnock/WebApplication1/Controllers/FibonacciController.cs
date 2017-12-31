using System.Web.Http;
using Services;

namespace KnockKnock.Controllers
{
    public class FibonacciController : ApiController
    {

      

       
        /// <summary>
        /// Returns the nth number in the fibonacci sequence.
        /// </summary>
        /// <param name="n">The index(n) of the fibonacci sequence.</param>
        /// <returns></returns>
        public long Get(long n)
        {
            return  KnockKnockService.Service.Fibonacci(n);
            
        }
    }
}