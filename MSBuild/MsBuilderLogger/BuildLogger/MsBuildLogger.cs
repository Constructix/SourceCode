using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;
namespace BuildLogger
{
    public class MsBuildLogger : Logger
    {
        private Stopwatch _watch;
        public override void Initialize(IEventSource eventSource)
        {

            _watch = new Stopwatch();
            
            eventSource.ProjectStarted += EventSource_ProjectStarted;
            eventSource.BuildFinished += EventSource_BuildFinished;
            eventSource.TargetStarted += EventSource_TargetStarted;
            eventSource.TargetFinished += EventSource_TargetFinished;
        }

        private void EventSource_TargetFinished(object sender, TargetFinishedEventArgs e)
        {
            Console.WriteLine($"Target Build has finished. - {e.TargetName}");
            Console.WriteLine();
        }

        private void EventSource_TargetStarted(object sender, TargetStartedEventArgs e)
        {
            Console.WriteLine($"Target Build has started. -  {e.TargetName}");
            Console.WriteLine();
        }

        private void EventSource_BuildFinished(object sender, BuildFinishedEventArgs e)
        {

            
            Console.WriteLine($"Build has Completed....");

            if(e.Succeeded)
                Console.WriteLine("Build Succeeded");
            else
                Console.WriteLine("Build Failed.");
            Console.WriteLine();
            _watch.Stop();
            Console.WriteLine($"Build Time was: {_watch.Elapsed.TotalSeconds} seconds.");
        }

        private void EventSource_ProjectStarted(object sender, ProjectStartedEventArgs e)
        {

            _watch.Start();
            Console.WriteLine($"Build has Started {e.ProjectFile}....");
            Console.WriteLine();
        }
    }
}
