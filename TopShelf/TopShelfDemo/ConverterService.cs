using System;
using System.IO;
using Topshelf.Logging;

namespace TopShelfDemo
{
    public class ConverterService
    {
        private FileSystemWatcher _watcher;
        private static readonly LogWriter Log = HostLogger.Get<ConverterService>();

        public bool Start()
        {
            _watcher  =new FileSystemWatcher(@"C:\Temp\a", "*_in.txt");

            _watcher.Created += _watcher_Created;
            _watcher.IncludeSubdirectories = false;
            _watcher.EnableRaisingEvents = true;

            return true;
        }
        public bool Stop()
        {
            _watcher.Dispose();
            return true;
        }

        private void _watcher_Created(object sender, FileSystemEventArgs e)
        {
            Log.InfoFormat("Starting conversion of '{0}'", e.FullPath);

            string content = File.ReadAllText(e.FullPath);
            string upperContent = content.ToUpperInvariant();
            var dir = Path.GetDirectoryName(e.FullPath);
            var convertedFileName = Path.GetFileName(e.FullPath) + ".converted";
            var convertedPath = Path.Combine(dir, convertedFileName);

            File.WriteAllText(convertedPath, upperContent);



        }

       
    }
}