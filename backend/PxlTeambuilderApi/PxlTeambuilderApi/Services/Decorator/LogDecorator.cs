using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Services.Implementations;
using PxlTeambuilderApi.Services.Interfaces;

namespace PxlTeambuilderApi.Services.Decorator
{
    public class LogDecorator : ProjectServiceDecorator
    {
        public LogDecorator(IProjectService service) : base(service)
        {
            Attach(new LogService(this, "ProjectService: "));
            SetStateAndNotify("Constructor Called");
        }
        public void SetStateAndNotify(string stateParameter)
        {
            State = stateParameter;
            this.Notify();
        }

        public override ICollection<Project> GetAllProjectsByUserId(int userId, string role)
        {
            SetStateAndNotify("GetAllProjectsByUserId Called");
            return base.GetAllProjectsByUserId(userId, role);
        }

        public override Task<Project> GetProjectByIdAsync(string projectId)
        {
            SetStateAndNotify("GetAllProjectsByUserId Called");
            return base.GetProjectByIdAsync(projectId);
        }

        public override Task<ICollection<Group>> GetGroupsFromProjectAsync(string projectId)
        {
            SetStateAndNotify("GetGroupsFromProjectAsync");
            return base.GetGroupsFromProjectAsync(projectId);
        }

        public override Task<Project> AddProjectAsync(Project project)
        {
            SetStateAndNotify("AddProjectAsync Called");
            return base.AddProjectAsync(project);
        }
    }
}
