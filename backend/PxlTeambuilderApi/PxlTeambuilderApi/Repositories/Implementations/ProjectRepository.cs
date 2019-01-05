﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PxlTeambuilderApi.Data;
using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Exceptions;

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

        private async Task<int> CommitAsync()
        {
          return await context.SaveChangesAsync();
        }

        public async Task<int> AddUserToGroup(int userId, string projectId, string groupId)
        {
            UserProjectDetail userProjectDetail = new UserProjectDetail
            {
                UserId = userId,
                ProjectId = projectId,
                GroupId = groupId
            };

            Project project = await context.Projects.FindAsync(projectId);
            if (project == null)
            {
                throw new ProjectNotFoundException(projectId);
            }

            Group group = await context.Groups.FindAsync(groupId);
            int groupCount = group.UserProjectDetails.Count;
            if (groupCount < project.MaxStudentsPerGroup)
            {
                await context.UserProjectDetails.AddAsync(userProjectDetail);
                return await CommitAsync();
            }

            else
            {
                throw new MaxStudentsBoundsException();
            }
        }

        public async Task<bool> UserIsAlreadyInProject(string projectId,int userId)
        {
            UserProjectDetail userProjectDetail = await context.UserProjectDetails.FindAsync(userId, projectId);
            if(userProjectDetail == null)
            {
                return false;
            }

            return true;
        }
    }
}
