using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Exceptions;
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
            Project project = await projectRepository.GetProjectByIdAsync(projectId);
            if(project == null)
            {
                throw new ProjectNotFoundException(projectId);
            }

            return project;
        }

        //TODO: implement
        //TODO: generate id for input project
        //TODO: add default group unnasigned to project
        public async Task<Project> AddProjectAsync(Project project)
        {
            project.ProjectId =  $"PXL-{Guid.NewGuid().ToString()}";
            project.Groups = new List<Group>();
            Group defaultGroup = GenerateDefaultGroup(project.ProjectId);
            project.Groups.Add(defaultGroup);
            return await projectRepository.AddProjectAsync(project);
        }

        //TODO: implement
        //TODO: check max amount of students per group for project
        public async Task<Project> UpdateProjectAsync(string projectId, Project project)
        {
            throw new NotImplementedException();
        }

        private Group GenerateDefaultGroup(string projectId)
        {
            return new Group()
            {
                GroupId = Guid.NewGuid().ToString(),
                Name = "Unassigned",
                ProjectId = projectId
            };
        }
    }
}
