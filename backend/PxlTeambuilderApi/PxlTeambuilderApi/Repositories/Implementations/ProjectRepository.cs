using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PxlTeambuilderApi.Data;
using PxlTeambuilderApi.Data.Domain;

namespace PxlTeambuilderApi.Repositories.Implementations
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly PxlTeamBuilderContext context;

        public ProjectRepository(PxlTeamBuilderContext context)
        {
            this.context = context;
        }

        public async Task<Project> GetProjectByIdAsync(string projectId)
        {
            return await context.Projects.FindAsync(projectId);
        }

        //TODO: implement
        public async Task<Project> AddProjectAsync(Project project)
        {
            throw new NotImplementedException();
        }

        //TODO: implement
        public async Task<Project> UpdateProjectAsync(string projectId, Project project)
        {
            throw new NotImplementedException();
        }
    }
}
