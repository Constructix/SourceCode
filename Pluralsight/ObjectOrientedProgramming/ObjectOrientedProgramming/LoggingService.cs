using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ObjectOrientedProgramming
{
    public class LoggingService
    {

        public string FileName { get; set; }
        
        public void WriteToLog(List<ILoggable> changedItems)
        {
            if(string.IsNullOrEmpty(FileName))
                throw new FileNotFoundException("FileName to the logging component has not been assigned. Please set the fileName.");

            StringBuilder logbuilder = new StringBuilder();
            foreach (ILoggable item in changedItems)
            {
                var currentLogDateTime = DateTime.Now.ToString("O");
                logbuilder.AppendLine($"{currentLogDateTime}" + item.Log());
            }
            System.IO.File.AppendAllText(this.FileName,  logbuilder.ToString() );
        }
    }
}