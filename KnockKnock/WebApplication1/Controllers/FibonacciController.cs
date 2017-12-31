using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Services;

namespace WebApplication1.Controllers
{
    public class FibonacciController : ApiController
    {

        private KnockKnockService _service;

        /// <summary>
        /// 
        /// </summary>
        public FibonacciController()
        {
            _service = new KnockKnockService();
        }
        /// <summary>
        /// Returns the nth number in the fibonacci sequence.
        /// </summary>
        /// <param name="n">The index(n) of the fibonacci sequence.</param>
        /// <returns></returns>
        public long Get(long n)
        {
            return _service.Fibonacci(n);
            
        }
    }
}