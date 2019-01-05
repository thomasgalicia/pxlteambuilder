using PxlTeambuilderApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Tests.Builders
{
    public class ProjectBuilder
    {
        private Project project;

        public ProjectBuilder()
        {
            project = new Project();
        }

        public Project Build()
        {
            return project;
        }

        public ProjectBuilder WithProjectId(string projectId)
        {
            project.ProjectId = projectId;
            return this;
        }

        public ProjectBuilder WithTitle(string title)
        {
            project.Title = title;
            return this;
        }
    }
}
