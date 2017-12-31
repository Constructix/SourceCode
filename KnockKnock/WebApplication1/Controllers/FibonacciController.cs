using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class FibonacciController : ApiController
    {
        public int Get(int n)
        {
            return PrivateFibonacci(n);
        }

        private int PrivateFibonacci(int num1)
        {
            int sum = 0;
            if (num1 <= 2)
                return 1;
            sum += PrivateFibonacci(num1 - 1) + PrivateFibonacci(num1 - 2);
            return sum;

        }
    }
}