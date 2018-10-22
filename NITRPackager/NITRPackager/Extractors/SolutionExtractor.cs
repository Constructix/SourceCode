using System.Collections.Generic;
using System.IO;
using System.Linq;
using NITRPackager.Models;

namespace NITRPackager.Extractors
{
    public class SolutionExtractor
    {
        private string solutionContents { get; set; }
        public List<ProjectDetail> Projects { get; private set; }
        public string SolutionLocation { get; private set; }

        public SolutionExtractor(string solutionLocation)
        {
            this.SolutionLocation = solutionLocation;
        }
        public void Extract()
        {
            if(!File.Exists(this.SolutionLocation))
                throw new FileNotFoundException(this.SolutionLocation);
            solutionContents = File.ReadAllText(this.SolutionLocation);
            ExtractProjectsFromSolution();
        }
        private void ExtractProjectsFromSolution()
        {
            ProjectDetailExtractor projectDetailExtractor = new ProjectDetailExtractor(solutionContents);
            projectDetailExtractor.Extract();
            this.Projects = projectDetailExtractor.Projects;
        }
    }
}