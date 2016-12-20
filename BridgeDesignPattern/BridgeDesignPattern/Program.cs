using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //var RefinedAbstraction = new RefinedBaseAbstraction(new ConcreteImplementorA());
            //RefinedAbstraction.LogMessage();
            //RefinedAbstraction = new RefinedBaseAbstraction(new ConcreteImplementorB());
            //RefinedAbstraction.LogMessage();



            var logManager=  new LogManager(new TextLogProvider());
            logManager.LogMessage("This is the console.");

            Console.WriteLine();

            logManager = new LogManager(new XmlLogProvider() {FileName = @"D:\Files\xmlLoggerTest.xml"});
            logManager.LogMessage("This is the Xml message");


        }
    }
}
