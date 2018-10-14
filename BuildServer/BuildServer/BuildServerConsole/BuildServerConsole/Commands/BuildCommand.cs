using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace BuildServerConsole
{
    internal class BuildCommand : BaseCommand
    {
        public string MsBuildPath { get; set; }
        public string ProjectName { get;  set; }

        public string LogFile { get; set; }
        public BuildCommand()
        {
            
        }

        public BuildCommand(string msBuildPath, string projectName, string logFile = "")
        {
            this.MsBuildPath = msBuildPath;
            this.ProjectName = projectName;
            this.LogFile = logFile;
        }

        private string LogFileParameter =>$"LogFile={this.LogFile}";
        
        public override void Execute()
        {

            // Need to update the AssemblyInfo.cs
            XDocument doc  = XDocument.Load(this.ProjectName);

            
           
            
            
            var csFiles = doc.Descendants().Where(x=>x.Name.LocalName.Equals("Compile"));
            var propertyFile = csFiles.Attributes().FirstOrDefault(y => y.Value.Equals(@"Properties\AssemblyInfo.cs"));

            if (propertyFile != null)
            {
                var fileName = propertyFile.Value;

                var folderLocation = Directory.GetParent(this.ProjectName);
                // Update assemblyVersion
                string pattern = @"AssemblyVersion\(\""\d.\d.\d.\d\"")]";


                var contents = File.ReadAllText(string.Format($"{folderLocation}\\{fileName}"));

                Match m = Regex.Match(contents, pattern);
                if (m.Success)
                {
                    int startPosition = m.Index;

                    var temp =  m.Value;

                    int firstInvertedCommaPos = temp.IndexOfAny(new char[] { '\"'});
                    int lastindex = temp.LastIndexOf('\"');

                    Version v = new Version(temp.Substring(firstInvertedCommaPos+1, lastindex - firstInvertedCommaPos - 1));

                }

            }





            if(string.IsNullOrWhiteSpace(this.ProjectName)) throw new Exception("Project name has not been specified.");
            DeleteExistingLogFile(this.LogFile);
            var buildProcessStartInfo = new ProcessStartInfo(@"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe");
            var buildProcessstartInfoArguements =
                $@"{this.ProjectName} -nologo -l:FileLogger,Microsoft.Build.Engine;{LogFileParameter};append=false -noconsolelogger"; 
            buildProcessStartInfo.CreateNoWindow = false;
            buildProcessStartInfo.RedirectStandardOutput = false;
            buildProcessStartInfo.UseShellExecute = false;
            buildProcessStartInfo.WindowStyle = ProcessWindowStyle.Hidden;

            buildProcessStartInfo.Arguments = buildProcessstartInfoArguements;
            buildProcess.StartInfo = buildProcessStartInfo;
            buildProcess.Start();
            buildProcess.WaitForExit();
        }

        private void DeleteExistingLogFile(string logFile)
        {
            if(System.IO.File.Exists(logFile))
                System.IO.File.Delete(logFile);
        }

        public override void Execute(string projectToBuild)
        {
            this.ProjectName = projectToBuild;
            Execute();   
        }
    }
}