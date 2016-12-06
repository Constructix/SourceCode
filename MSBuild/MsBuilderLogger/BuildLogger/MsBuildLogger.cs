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
        }

        private void EventSource_TargetStarted(object sender, TargetStartedEventArgs e)
        {
            Console.WriteLine($"Target Build has started.");
            Console.WriteLine();
        }

        private void EventSource_BuildFinished(object sender, BuildFinishedEventArgs e)
        {
            Console.WriteLine($"Build has Completed....");
            Console.WriteLine();
            _watch.Stop();
            Console.WriteLine($"Build Time was: {_watch.Elapsed.TotalMilliseconds}");
        }

        private void EventSource_ProjectStarted(object sender, ProjectStartedEventArgs e)
        {

            _watch.Start();
            Console.WriteLine($"Build has Started {e.ProjectFile}....");
            Console.WriteLine();
        }
    }
}
