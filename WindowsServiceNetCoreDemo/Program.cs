using System;
using System.IO;
using System.ServiceProcess;

namespace WindowsServiceNetCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TestService svc = new TestService())
            {
                ServiceBase.Run(svc);
            }
        }
    }

    public class TestService : ServiceBase
    {

        public TestService()
        {
            ServiceName = "TestService";
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);

            var fileName = CheckFileExists();
            File.AppendAllText(fileName, $"{DateTime.Now} started. {Environment.NewLine}");
        }

        protected override void OnStop()
        {
            var fileName = CheckFileExists();
            File.AppendAllText(fileName, $"{DateTime.Now} stopped.{Environment.NewLine}");
        }

        public static string CheckFileExists()
        {
            string fileName = @"C:\LogFiles\WindowsService.log";

            if (!File.Exists(fileName))
            {
                File.Create(fileName);
            }

            return fileName;
        }
    }
}
