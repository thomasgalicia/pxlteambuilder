using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Data.Enums;
using PxlTeambuilderApi.Exceptions;
using PxlTeambuilderApi.Repositories.Implementations;
using PxlTeambuilderApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PxlTeambuilderApi.Services.Abstract;

namespace PxlTeambuilderApi.Services.Implementations
{
    public class ProjectService : LogComponent, IProjectService
    {
        private readonly IProjectRepository projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
            //attaching this as publisher to subscriber LogService
            Attach(new LogService(this, "ProjectService: "));
            SetStateAndNotify("Constructor Called");
        }

        public void SetStateAndNotify(string stateParameter)
        {
            State = stateParameter;
            this.Notify();
        }

        public ICollection<Project> GetAllProjectsByUserId(int userId, string role)
        {
            UserRole userRole = UserRole.Student;
            if(role.ToLower() == "teacher")
            {
                userRole = UserRole.Teacher;
            }

            SetStateAndNotify("GetAllProjectsByUserId Called");
            return projectRepository.GetAllProjectsByUserId(userId, userRole);
        }

        public async Task<Project> GetProjectByIdAsync(string projectId)
        {
            Project project = await projectRepository.GetProjectByIdAsync(projectId);
            if(project == null)
            {
                throw new ProjectNotFoundException(projectId);
            }

            SetStateAndNotify("GetProjectByIdAsync Called");
            return project;
        }

        public async Task<ICollection<Group>> GetGroupsFromProjectAsync(string projectId)
        {
            SetStateAndNotify("GetGroupsFromProjectAsync");
            return await projectRepository.GetAllGroupsOfProjectAsync(projectId);
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            project.ProjectId =  $"PXL-{Guid.NewGuid().ToString()}";
            project.Groups = new List<Group>();
            Group defaultGroup = GenerateDefaultGroup(project.ProjectId);
            project.Groups.Add(defaultGroup);

            SetStateAndNotify("AddProjectAsync Called");
            return await projectRepository.AddProjectAsync(project);
        }

        //TODO: implement
        //TODO: check max amount of students per group for project
        public async Task<Project> UpdateProjectAsync(string projectId, Project project)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddUserToGroup(int userId,string projectId ,string groupId)
        {
            if (await projectRepository.UserIsAlreadyInProject(projectId, userId))
            {
                throw new UserAlreadyInProjectException();
            }

            int rowsAdded = await projectRepository.AddUserToGroup(userId, projectId, groupId);
            if(rowsAdded == 1)
            {
                return true;
            }

            return false;
        }

        private Group GenerateDefaultGroup(string projectId)
        {
            SetStateAndNotify("GenerateDefaultGroup Called");
            return new Group()
            {
                GroupId = Guid.NewGuid().ToString(),
                Name = "Unassigned",
                ProjectId = projectId
            };
        }

    }
}
