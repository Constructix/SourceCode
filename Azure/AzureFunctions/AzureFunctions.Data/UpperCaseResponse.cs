using System;
using System.Collections.Generic;

namespace AzureFunctions.Data
{
    public class UpperCaseResponse
    {
        public string Message { get; set; }
        public DateTimeOffset Created { get; set; }
        public List<string> Values { get; set; }
    }
}