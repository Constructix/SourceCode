using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace TopShelfDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            HostFactory.Run(serviceconfig =>
            {
                serviceconfig.UseNLog();

                serviceconfig.Service<ConverterService>(serviceinstance =>
                {


                    serviceinstance.ConstructUsing(() => new ConverterService());

                    serviceinstance.WhenStarted(execute => execute.Start());
                    serviceinstance.WhenStopped(execute => execute.Stop());

                });

                serviceconfig.SetServiceName("AwesomeFileConverter");
                serviceconfig.SetDisplayName("Awesome File Converter Pluralsight");
                serviceconfig.SetDescription("A Pluralsight demo service.");


                serviceconfig.StartAutomatically();
            });
        }
    }
}
