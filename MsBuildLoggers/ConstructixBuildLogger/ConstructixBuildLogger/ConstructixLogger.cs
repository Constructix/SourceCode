using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;
using Console = System.Console;

namespace ConstructixBuildLogger
{
    public class ConstructixLogger : ILogger
    {
        private DateTime startTime;
        private DateTime endTime;

        public void Initialize(IEventSource eventSource)
        {
            Console.WriteLine("Constructix BuildLogger has started....");
            startTime = DateTime.Now;
            Console.WriteLine($"Build Started: {startTime}");
            eventSource.ProjectStarted += EventSource_ProjectStarted;
            eventSource.ProjectFinished += EventSource_ProjectFinished;
            eventSource.TaskFinished += EventSource_TaskFinished;
        }

        private void EventSource_TaskFinished(object sender, TaskFinishedEventArgs e)
        {
            Console.WriteLine(e.TaskName);
        }

        private void EventSource_ProjectFinished(object sender, ProjectFinishedEventArgs e)
        {
            Console.WriteLine("Constructix buildLogger has finished.");
            Console.WriteLine(e.Timestamp.ToString());
            var result = e.Succeeded ? "Success" : "Failure";
            Console.WriteLine($"Build Status: {result}");
        }

        private void EventSource_ProjectStarted(object sender, ProjectStartedEventArgs e)
        {
           Console.WriteLine($"\tStarted to Build ->{e.ProjectFile}");
        }

        public void Shutdown()
        {
            Console.WriteLine("\tConstructixLogger shutting down.");
        }

        public LoggerVerbosity Verbosity { get; set; }
        public string Parameters { get; set; }
    }
}
