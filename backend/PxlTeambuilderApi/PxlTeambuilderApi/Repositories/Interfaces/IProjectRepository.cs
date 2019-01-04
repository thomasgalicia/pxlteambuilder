using PxlTeambuilderApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Repositories.Implementations
{
    public interface IProjectRepository
    {
        Task<Project> GetProjectByIdAsync(string projectId);
        Task<Project> AddProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(string projectId, Project project);
    }
}
