using System.Diagnostics;

namespace BuildServerConsole
{
    public class ConsoleCommand : BaseCommand
    {
        public string LogFile { get; }
        

        public override void Execute()
        {
            buildProcess = new Process();
            buildProcess.StartInfo = new ProcessStartInfo("notepad.exe",LogFile);
            
            buildProcess.Start();
        }

        public ConsoleCommand(string logFile)
        {
            LogFile = logFile;
        }

        public override void Execute(string command)
        {
            throw new System.NotImplementedException();
        }
    }
}