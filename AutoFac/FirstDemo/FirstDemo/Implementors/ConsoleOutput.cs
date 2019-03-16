using System;
using FirstDemo.Interfaces;

namespace FirstDemo.Implementors
{
    public class ConsoleOutput : IOutput
    {
        public void Write(string content)
        {
            Console.WriteLine(content);
        }
    }
}