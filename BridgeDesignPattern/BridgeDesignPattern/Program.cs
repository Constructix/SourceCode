using System;
using System.Collections.Generic;
using System.IO;
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


            var fileManager = new FolderManager() {FileName = "xmlLoggerTest.xml", FolderName = "Files5", Drive = "C"};
            fileManager.Create();
            var logManager=  new LogManager(new TextLogProvider());
            logManager.LogMessage("This is the console.");

            Console.WriteLine();
            logManager = new LogManager(new XmlLogProvider { FileName = fileManager.ToString()});
            logManager.LogMessage("This is the Xml message");


        }

        private static void CreateFileFolder(string folderName)
        {


            System.IO.Directory.CreateDirectory($"{GetDefaultDrive}\\{folderName}");
        }


        private static string GetDefaultDrive
        {
            get { return System.IO.DriveInfo.GetDrives().FirstOrDefault(d => d.Name.StartsWith("C"))?.Name; }


        }
    }
}
