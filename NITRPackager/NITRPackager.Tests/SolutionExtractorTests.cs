using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NITRPackager.Extractors;
using NITRPackager.Models;

namespace NITRPackager.Tests
{
    public static class Constants
    {
        public const string  SolutionFileLocation = @"C:\Users\Richard\source\repos\NITRPackager\SampleSolution\DownloadFromNetTaskFactory\DownloadFromNetTaskFactory.sln";
    }

    [TestClass]
    public class SolutionExtractorTests
    {
        private SolutionExtractor extractor;
        
        [TestInitialize]
        public void Initialise()
        {
            // baseline initialise extractor object.
            extractor = new SolutionExtractor(Constants.SolutionFileLocation);
        }

        [TestMethod]
        public void OpenSolutionThatIsPassedIntoExtractorConstructor()
        {
            Assert.IsNotNull(extractor);
            var expectedSolutionLocation =Constants.SolutionFileLocation;
            var actual = extractor.SolutionLocation;
            Assert.IsTrue(expectedSolutionLocation.Equals(actual));
        }

        [TestMethod]
        public void ExtractProjectsFromSolutionFileDoesNotExist()
        {

            //Arrange
            const string solutionName = @"C:\Users\Richard\source\repos\NITRPackager\SampleSolution\DownloadFromNetTaskFactory1\DownloadFromNetTaskFactory.sln";
            //Act
            extractor = new SolutionExtractor(solutionName);
            //ASSERT
            var ex = Assert.ThrowsException<FileNotFoundException>(() => extractor.Extract());
        }

        [TestMethod]
        public void  ExtractProjectsFromSolutionFileExistsNoExceptionExpected()
        {
            // Arrange
            // use default solution file.
            // Act
            extractor = new SolutionExtractor(Constants.SolutionFileLocation);
            //Assert
            extractor.Extract();
        }

        [TestMethod]
        public void ExtractProjectDetailsFromSolutionFile()
        {
            //Arrange
            var expectedProjects = 1;
            // Act
            extractor = new SolutionExtractor(Constants.SolutionFileLocation);
            extractor.Extract();
            // Assert
            Assert.IsTrue(expectedProjects == extractor.Projects.Count());

            foreach (ProjectDetail currentProjectDetail in extractor.Projects)
            {
                Console.WriteLine($"{currentProjectDetail.Name} {currentProjectDetail.Location}");
            }
        }
    }
}
