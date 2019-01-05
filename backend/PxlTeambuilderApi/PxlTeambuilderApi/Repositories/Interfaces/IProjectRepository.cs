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
        Task<int> AddUserToGroup(int userId, string projectId, string groupId);
        Task<bool> UserIsAlreadyInProject(string projectId,int userId);
    }
}
