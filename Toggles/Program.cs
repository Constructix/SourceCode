using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


            EnableToggle  toggle =new EnableToggle();

            if (toggle.IsEnabled)
            {
                Console.WriteLine("EnableToggle is enabled.");
            }
            else
            {
                Console.WriteLine("EnableToggle is NOT Enabled.");
            }
        }
    }


    public class EnableToggle
    {

        public EnableToggle()
        {
            // Need to retrieve from app config to see if the class is registered in the appconfig and the value IsEnabled.


            this.IsEnabled = bool.Parse(ConfigurationManager.AppSettings["ConsoleApplication1.EnableToggle"]);
        }

        public bool IsEnabled { get; private set; }
    }
}
