using System;
using System.Collections.Generic;
using System.Text;

namespace AWSLambda7
{
    public class PersonResponse
    {
        public Guid Id {get;set;}
        public DateTime DateTimeStamp {get;set;}

        public string Details {get;set;}


        public PersonResponse()
        {
            Id =Guid.NewGuid();
            DateTimeStamp = DateTime.Now.ToUniversalTime();            
        }

    }
}
