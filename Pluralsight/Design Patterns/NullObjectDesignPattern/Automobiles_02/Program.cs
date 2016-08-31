using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobiles_02
{
    class Program
    {
        static void Main(string[] args)
        {
            var autoRepository =  new AutoRepository();

            AutomobileBase automobile = autoRepository.Find("BMW");

            automobile.Start();
            automobile.Stop();
        }
    }
}
