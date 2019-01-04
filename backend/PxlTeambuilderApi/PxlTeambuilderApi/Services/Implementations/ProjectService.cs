using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        public Task<Project> GetProjectByIdAsync(int projectId)
        {
            throw new NotImplementedException();
        }

        //TODO: implement
        public Task<Project> AddProjectAsync(Project project)
        {
            throw new NotImplementedException();
        }

        //TODO: implement
        //TODO: check max amount of students per group for project
        public Task<Project> UpdateProjectAsync(int projectId, Project project)
        {
            throw new NotImplementedException();
        }
    }
}
