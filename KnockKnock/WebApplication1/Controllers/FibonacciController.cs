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
            return Fibonacci(n);
            
        }
        public long Fibonacci(long num1)
        {
            long sum = 0;
            if (num1 <= 2)
                return 1;
            sum += Fibonacci(num1 - 1) + Fibonacci(num1 - 2);
            return sum;

        }
    }
}