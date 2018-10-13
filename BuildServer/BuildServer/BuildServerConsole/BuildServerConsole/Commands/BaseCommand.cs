using System.Diagnostics;

namespace BuildServerConsole
{
    public abstract class BaseCommand
    {
        protected Process buildProcess = new Process();
        public abstract void Execute();

        public abstract void Execute(string command);
    }
}