using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Repositories.Implementations;
using PxlTeambuilderApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Services.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<Project> GetProjectByIdAsync(string projectId)
        {
            return await projectRepository.GetProjectByIdAsync(projectId);
        }

        //TODO: implement
        public async Task<Project> AddProjectAsync(Project project)
        {
            throw new NotImplementedException();
        }

        //TODO: implement
        //TODO: check max amount of students per group for project
        public async Task<Project> UpdateProjectAsync(string projectId, Project project)
        {
            throw new NotImplementedException();
        }
    }
}
