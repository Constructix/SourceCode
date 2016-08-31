using System;

namespace Automobiles_01
{
    internal class AutoMobile
    {

        public string Name { get; set; }

        public void Start()
        {
            Console.WriteLine($"{Name} started.");
        }

        public void Stop()
        {
            Console.WriteLine($"{Name} stopped.");
        }
    }
}