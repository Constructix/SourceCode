using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automobiles_01
{
    class Program
    {
        static void Main(string[] args)
        {

            var autoRepository = new AutoRepository();
            var automobiles = autoRepository.FindAllByName("ford");

            foreach (AutoMobile automobile in automobiles)
            {
                automobile.Start();
                automobile.Stop();
            }
        }
    }
}
