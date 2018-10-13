using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BuildServerConsole
{

    public class BuildManagerEventArgs : EventArgs
    {
        public string Message { get; set; }

        public BuildManagerEventArgs(string message)
        {
            this.Message = message;
        }
    }

    public class BuildManager
    {

        public event EventHandler<BuildManagerEventArgs> BuildManagerEvent;

        public string MsBuildPath { get;set; }
        
        public List<BaseCommand> Commands { get; set; }

        public BuildManager()
        {
            Commands= new List<BaseCommand>();
        }
        public void AddCommand(BaseCommand command)
        {
            Commands.Add(command);
        }


        public void Start()
        {
            foreach (var currentCommand in Commands)
            {
                currentCommand.Execute();
            }

            EventHandler<BuildManagerEventArgs> _event = BuildManagerEvent;
            _event?.Invoke(this, new BuildManagerEventArgs("Build completed..."));

            // Look up in the file file and check if the status is successfull.

            string BuildSuccessPattern = "Build succeeded.";

            BuildCommand buildCommand = (BuildCommand) Commands.FirstOrDefault(x => x.GetType().Name.Equals("BuildCommand"));

            var logFileContents = System.IO.File.ReadAllText(buildCommand.LogFile);

            Match match = Regex.Match(logFileContents, BuildSuccessPattern);
            if (match.Success)
            {
                _event = BuildManagerEvent;
                _event?.Invoke(this, new BuildManagerEventArgs("Build succeeded."));
            }

            string buildFailedPattern = "Build FAILED.";

            match = Regex.Match(logFileContents, buildFailedPattern);
            if (match.Success)
            {

                string timeElapsed = "Time Elapsed";
                var timeElapsedMatch = Regex.Match(logFileContents, timeElapsed);
                if (timeElapsedMatch.Success)
                {
                    int timeElapsedIndex = timeElapsedMatch.Index;
                    var errors = logFileContents.Substring(match.Index+ buildFailedPattern.Length,
                        timeElapsedIndex - (match.Index + buildFailedPattern.Length));
                    _event = BuildManagerEvent;
                    _event?.Invoke(this, new BuildManagerEventArgs($"Build failed.{Environment.NewLine}{errors}"));
                }
            }
        }
    }

   
}