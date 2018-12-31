using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRecognitionNetFrameworkDemo
{
    public class S3ObjectDetail
    {
        public string Name { get; }

        public S3ObjectDetail(string name)
        {
            Name = name;
        }
    }
}
