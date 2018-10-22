using System;
using System.Linq;
using System.Xml.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NITRPackager.Tests
{
    [TestClass]
    public class ProjectExtractor
    {

        [TestInitialize]
        public void Initialise()
        {

        }

        [TestMethod]
        public void ProjectExtractorNoExceptionExpected()
        {
        }

        [TestMethod]
        public void ExtractCSharpFiles()
        {
            var fileName =@"C:\Users\Richard\source\repos\NITRPackager\SampleSolution\DownloadFromNetTaskFactory\DownloadFromNetTaskFactory\DownloadFromNetTaskFactory.csproj";

            XDocument doc = XDocument.Load(fileName);

            //get all csharp files.
            var csharpFiles =  doc.Descendants().Where(x => x.Name.LocalName.Equals("Compile"));
            foreach (XElement csharpFile in csharpFiles)
            {
                Console.WriteLine(csharpFile.FirstAttribute.Value);
            }
        }
        
    }
}