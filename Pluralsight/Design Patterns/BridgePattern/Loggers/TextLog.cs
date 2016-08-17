using System;

namespace BridgePattern
{
    public class TextLog : ILog
    {
        public TextLog()
        {

        }

        public TextLog(string fileName)
        {
            this.FileName = fileName;
        }

        public string FileName { get; set; }
        public void LogMessage(string messageToLog)
        {
            System.IO.File.AppendAllText(FileName, string.Format($"{messageToLog}{Environment.NewLine}"));
        }
    }
}