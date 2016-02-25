using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomConfigFileDemo;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (FileElement file in FileRetriever.GetFiles())
            {
                Console.WriteLine(file.SourcePath);
                Console.WriteLine(file.DestinationPath);
                //DO WORK 
            }

        }
    }
}
