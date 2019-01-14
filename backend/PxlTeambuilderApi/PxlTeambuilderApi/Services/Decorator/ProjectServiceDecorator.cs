using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Services.Abstract;
using PxlTeambuilderApi.Services.Interfaces;

namespace PxlTeambuilderApi.Services.Decorator
{
    public abstract class ProjectServiceDecorator: LogComponent,IProjectService
    {
        public string State { get; set; }
        protected IProjectService _service;
        public ProjectServiceDecorator(IProjectService service)
        {
            _service = service;
        }
        public virtual ICollection<Project> GetAllProjectsByUserId(int userId, string role)
        {
            return _service.GetAllProjectsByUserId(userId, role);
        }

        public virtual Task<Project> GetProjectByIdAsync(string projectId)
        {
            return _service.GetProjectByIdAsync(projectId);
        }

        public virtual Task<ICollection<Group>> GetGroupsFromProjectAsync(string projectId)
        {
            return _service.GetGroupsFromProjectAsync(projectId);
        }

        public virtual Task<Project> AddProjectAsync(Project project)
        {
            return _service.AddProjectAsync(project);
        }

        public virtual Task<Project> UpdateProjectAsync(string projectId, Project project)
        {
            return _service.UpdateProjectAsync(projectId, project);
        }

        public virtual Task<bool> AddUserToGroup(int userId, string projectId, string groupId)
        {
            return _service.AddUserToGroup(userId,projectId,groupId);
        }
    }
}
