using System;

namespace NITRPackager.Models
{
    public class ProjectDetail
    {
        public Guid ProjectId { get; }
        public string Name { get; }
        public string Location { get; }

        public ProjectDetail( string name, string projectLocation, Guid projectId)
        {
            ProjectId = projectId;
            Name = name;
            this.Location = projectLocation;

        }
    }
}