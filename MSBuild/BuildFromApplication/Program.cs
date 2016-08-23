using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.BuildEngine;
using Microsoft.Build.Evaluation;
using Microsoft.Build.Execution;
using Microsoft.Build.Framework;
using Microsoft.Build.Tasks;
using ConsoleLogger = Microsoft.Build.Logging.ConsoleLogger;
using Project = Microsoft.Build.Evaluation.Project;

namespace MsBuildDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildSolution();
            //Dictionary<string, string> globalProperty = new Dictionary<string, string>();
            //globalProperty.Add("Platform", "Any CPU");

            //ILogger logger = new BasicFileLogger { Parameters = @"D:\Files\build.log", Verbosity = LoggerVerbosity.Detailed };


            //var project = new Project(@"D:\Files\MsBuild\MultiMake.proj", globalProperty, "4.0"); //{FullPath = @"D:\Files\MsBuild\MultiMake.proj", };
            //project.IsBuildEnabled = true;


            //List<ILogger> loggers = new List<ILogger>();
            //loggers.Add(logger);

            //string [] items = new string[0];
            //project.Build(items, loggers);

        }

        private static void Pc_ProjectAdded(object sender, ProjectCollection.ProjectAddedToProjectCollectionEventArgs e)
        {
            Console.WriteLine(e.ProjectRootElement.FullPath);
        }

        private static void BuildSolution()
        {
// This does solution not projects
            string projectFileName = @"D:\Files\MsBuild\MultiMake.proj";


            ProjectCollection pc = new ProjectCollection();
            Dictionary<string, string> globalProperty = new Dictionary<string, string>();
            globalProperty.Add("Platform", "Any CPU");

            BuildParameters bp = new BuildParameters(pc);

            ILogger logger = new BasicFileLogger {Parameters = @"D:\Files\build.log", Verbosity = LoggerVerbosity.Detailed};

            bp.Loggers = new List<ILogger> {logger};


            BuildManager.DefaultBuildManager.BeginBuild(bp);
            BuildRequestData buildRequest = new BuildRequestData(projectFileName, globalProperty, null, new string[] {"Build"},
                null);

            BuildSubmission buildSubmission = BuildManager.DefaultBuildManager.PendBuildRequest(buildRequest);

            buildSubmission.Execute();

            BuildManager.DefaultBuildManager.EndBuild();
            var result = buildSubmission.BuildResult.OverallResult;

            Console.WriteLine(result);

            if (buildSubmission.BuildResult.OverallResult == BuildResultCode.Failure)
            {
            }
        }
    }
}
