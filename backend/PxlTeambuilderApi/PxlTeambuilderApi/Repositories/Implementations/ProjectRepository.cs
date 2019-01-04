using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        //TODO: handle exception when user does not exist
        public async Task<Project> AddProjectAsync(Project project)
        {
            EntityEntry projectEntry = await context.Projects.AddAsync(project);
            Project insertedEntity = (Project)projectEntry.Entity;
            try{
                await CommitAsync();

            }

            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return insertedEntity;
        }

        //TODO: implement
        public async Task<Project> UpdateProjectAsync(string projectId, Project project)
        {
            throw new NotImplementedException();
        }

        private async Task CommitAsync()
        {
           await context.SaveChangesAsync();
        }
    }
}
