using System;
using Microsoft.AspNetCore.Http;

namespace AspNETCoreFiltersDemo.Exceptions
{
    public class HttpResponseException : Exception
    {
        public int Status { get; set; } = 500;

        public object Value { get; set; }



        public static HttpResponseException InvalidID => new HttpResponseException { Status = 400, Value = "There is no Product Id that matches the id supplied." };
    }
}