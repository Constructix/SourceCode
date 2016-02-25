using System;

namespace Constructix.Config.FileRetrieve.Client
{
    static class Program
    {

        // get the settings from the config file.
        static void Main(string[] args)
        {
            foreach (FileElement file in FileRetriever.GetFiles())
            {
                Console.WriteLine(file.SourcePath);
                Console.WriteLine(file.DestinationPath);
                
            }

        }
    }
}
