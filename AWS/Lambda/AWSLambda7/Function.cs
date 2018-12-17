using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace AWSLambda7
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            // need to serialise an object
            return input?.ToUpper();
        }
    }

    //public class Handler
    //{
    //    [LambdaSerializer(typeof(JsonSerializer))]
    //    public Result Handle(Request request) 
    //    {
    //        return new Result { HelloWorld = request.Name };
    //    }
    //}

    public class PersonHandler
    {
        [LambdaSerializer(typeof(JsonSerializer))]
        public PersonResponse Handle(PersonRequest request)
        {
            PersonResponse response = new PersonResponse();
            response.Details = "This is cool, getting Lambda functions working on AWS.";
            return response;
        }
    }

    public class Request
    {
        public string Name { get; set; }
    }

    public class Result
    {
        public string HelloWorld { get; set; }
    }



    public class PersonRequest
    {
        public string FirstName {get;set;}
        public string LastName {get;set;}
    }   
}
