using System;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NITRPackager.Extractors;

namespace NITRPackager.Tests
{
    [TestClass]
    public class ProjectDetailsExctractorTests
    {
        [TestMethod]
        public void ProjectDetailsExtractorInstanceCreated()
        {
            // Arrange
            var projectExtractor = new ProjectDetailExtractor(File.ReadAllText(Constants.SolutionFileLocation));
            // Act
            projectExtractor.Extract();
            // Assert
            Assert.IsTrue(projectExtractor.Projects.Count == 1);
            Assert.IsTrue(projectExtractor.Projects.Any(x=>x.Name.Equals("DownloadFromNetTaskFactory")));
        }
        //DownloadFromNetTaskFactory\DownloadFromNetTaskFactory.csproj
        [TestMethod]
        public void ProjectDetailsExtractorLocation()
        {
            // Arrange
            var projectExtractor = new ProjectDetailExtractor(File.ReadAllText(Constants.SolutionFileLocation));
            // Act
            projectExtractor.Extract();
            // Assert
            Assert.IsTrue(projectExtractor.Projects.Count == 1);
            Assert.IsTrue(projectExtractor.Projects.Any(x =>x.Location.Equals(@"DownloadFromNetTaskFactory\DownloadFromNetTaskFactory.csproj")));
        }

        [TestMethod]
        public void ProjectDetailsExtractorProjectGuid()
        {
            // Arrange
            var projectExtractor = new ProjectDetailExtractor(File.ReadAllText(Constants.SolutionFileLocation));
            // Act
            projectExtractor.Extract();
            // Assert
            Assert.IsTrue(projectExtractor.Projects.Count == 1);
            Guid.TryParse("F827A67D-B0A9-45F2-BA8E-D69847B44E2D", out Guid expecteId);
            Assert.IsTrue(projectExtractor.Projects.Any(x=>x.ProjectId.Equals(expecteId)));
        }
    }
}