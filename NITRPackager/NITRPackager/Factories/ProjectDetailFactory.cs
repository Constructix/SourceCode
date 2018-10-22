using System;
using System.Text.RegularExpressions;
using NITRPackager.Models;

namespace NITRPackager.Factories
{
    public class ProjectDetailFactory
    {
        public static ProjectDetail Create(string currentProjectDetail)
        {
            var namePattern = @"\""\w*""";
            var subString = Regex.Match(currentProjectDetail, namePattern).Value.Substring(1);
            var name = subString.Substring(0, subString.Length - 1);

            var projectPattern = @", \""\w*.*\.csproj""";
            subString = Regex.Match(currentProjectDetail, projectPattern).Value.Substring(3);
            var project = subString.Substring(0, subString.Length - 1);

            var idPattern = @" \""{\w*.*}""";
            subString = Regex.Match(currentProjectDetail, idPattern).Value.Substring(3);

            Guid.TryParse(subString.Substring(0, subString.Length - 2), out Guid projectId);
            return new ProjectDetail(name, project, projectId);
        }
    }
}