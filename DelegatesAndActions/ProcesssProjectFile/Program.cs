using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ProcesssProjectFile
{
    class Program
    {
        static void Main(string[] args)
        {

            string projectFileName = @"D:\GitHub\DelegatesAndActions\DelegateDemo\DelegateDemo.csproj";

            XDocument doc =  XDocument.Load(projectFileName);


            if (doc == null)
            {

                Environment.ExitCode = 1;
                return;
            }


            Console.WriteLine("Extracting project details from proj file.");
            Console.WriteLine(new string('-', 80));
            Console.WriteLine($"Folder Location: {new System.IO.FileInfo(projectFileName).Directory}");

            var cSharpFiles = doc.Descendants().Where(x => x.Name.LocalName.Equals("Compile")).Select(f=>f.Attribute("Include").Value);

            foreach (string currentCSharpFileItem in cSharpFiles)
            {
                Console.WriteLine(currentCSharpFileItem);
            }

            // create system file watchers....
            string msbuildLocation = @"MSBuild";
            //Process process = System.Diagnostics.Process.Start($"{msbuildLocation},${projectFileName}");
            //while (!process.HasExited)
            //{
                
            //}

            System.Diagnostics.Process.Start("MSBuild.exe", projectFileName);

        }
    }
}
