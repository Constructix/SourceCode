using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SCP.Contracts;

namespace SCP.Services
{
    public class LongRunningManager : ILongRunningService
    {
        List<int> numbers = new List<int>();
        public void StartProcess()
        {

            
            Random r = new Random();

            for (int i = 0; i < 100; i++)
            {
                int gen = r.Next();
                Console.WriteLine($"Generated : {gen}");
                numbers.Add(gen);

                Thread.Sleep(3000);
            }

        }
    }
}
