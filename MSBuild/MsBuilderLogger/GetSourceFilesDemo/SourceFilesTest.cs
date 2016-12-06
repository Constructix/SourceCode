using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Xunit;
using Xunit.Abstractions;

namespace GetSourceFilesDemo
{
    public class SourceFilesTest
    {
        private readonly ITestOutputHelper _helper;

        public SourceFilesTest(ITestOutputHelper helper)
        {
            _helper = helper;
        }
        private  const string fileName = @"D:\GitHub\MSBuild\MsBuilderLogger\BuildLogger\BuildLogger.csproj";
        [Fact]
        public void OpenProjectFile()
        {
            
            XDocument doc = XDocument.Load(System.IO.File.OpenRead(fileName));
            Assert.NotNull(doc);
        }

        [Fact]
        public void GetCSharpFilesFromProjectFile()
        {
            XDocument doc = XDocument.Load(fileName);
            Dictionary<string, string> cSharpFiles = new Dictionary<string, string>();
            var files = doc.Descendants().Where(x => x.Name.LocalName.Equals("Compile"));

            foreach (XElement xElement in files)
            {
                var currentCSharpFile = xElement.Attributes().FirstOrDefault().Value;
                cSharpFiles.Add(currentCSharpFile, currentCSharpFile);
            }

            Assert.True(cSharpFiles.Any());
            Assert.True(cSharpFiles.Count == 2);

            PrintOutCSharpFiles(cSharpFiles);
        }

        private void PrintOutCSharpFiles(Dictionary<string, string> cSharpFiles)
        {
            foreach (var keyValuePair in cSharpFiles)
            {
                _helper.WriteLine(keyValuePair.Value);
            }
        }
    }
}
