using System;
using System.CodeDom;
using System.IO;
using System.ServiceProcess;

namespace WindowServiceInNETCoreDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var service = new TestService())
            {
                ServiceBase.Run(service);
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
            string fileName = CheckFileName();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine($"Service has started{Environment.NewLine}");
                    writer.Close();
                }

                fs.Close();
            }
        }

        protected override void OnStop()
        {
            string fileName = CheckFileName();
            using (FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine($"Service has Stopped{Environment.NewLine}");
                    writer.Close();
                }
                fs.Close();
            }
        }

        private string CheckFileName()
        {
            return  @"d:\Files\Constructix.txt";
            
        }
    } 
}
