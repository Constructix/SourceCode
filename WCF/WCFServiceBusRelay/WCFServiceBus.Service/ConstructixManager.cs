using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFServiceBus.Contracts;

namespace WCFServiceBus
{
    public class ConstructixManager : IConstructixManager
    {
        public int Add(int number1, int number2)
        {

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Call to Add() received.");
            return number1 + number2;
        }
    }
}
