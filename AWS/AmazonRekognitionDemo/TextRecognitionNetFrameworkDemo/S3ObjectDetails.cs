using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRecognitionNetFrameworkDemo
{
    public class S3ObjectDetails
    {
        public string Name { get; }

        public S3ObjectDetails(string name)
        {
            Name = name;
        }
    }
}
