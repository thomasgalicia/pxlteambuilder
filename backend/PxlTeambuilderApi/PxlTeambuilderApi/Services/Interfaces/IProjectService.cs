using PxlTeambuilderApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Services.Interfaces
{
    public interface IProjectService
    {
        Task<Project> GetProjectByIdAsync(int projectId);
        Task<Project> AddProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(int projectId, Project project);
    }
}
