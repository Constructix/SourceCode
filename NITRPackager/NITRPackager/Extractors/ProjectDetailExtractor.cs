using System.Collections.Generic;
using System.Text.RegularExpressions;
using NITRPackager.Factories;
using NITRPackager.Models;

namespace NITRPackager.Extractors
{
    public class ProjectDetailExtractor
    {
        private string solutionFileContents { get; }

        public ProjectDetailExtractor()
        {
            Projects = new List<ProjectDetail>();
        }
        public ProjectDetailExtractor(string readAllText) : this()
        {
            solutionFileContents = readAllText;
        }

        public  List<ProjectDetail> Projects { get; set; }

        public void Extract()
        {

            string ProjectPattern = @"Project\(\""*.*\nEndProject";
            var availableMatches = Regex.Matches(this.solutionFileContents, ProjectPattern);
            if (availableMatches.Count > 0)
            {
                foreach (Match currentMatch in availableMatches)
                {
                    Projects.Add(ProjectDetailFactory.Create(currentMatch.Value));
                }
            }
        }
    }
}