﻿using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Repositories.Implementations
{
    public interface IProjectRepository
    {
        ICollection<Project> GetAllProjectsByUserId(int userId, UserRole role);
        Task<Project> GetProjectByIdAsync(string projectId);
        Task<ICollection<Group>> GetAllGroupsOfProjectAsync(string projectId);
        Task<Project> AddProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(string projectId, Project project);
        Task<int> AddUserToGroup(int userId, string projectId, string groupId);
        Task<bool> UserIsAlreadyInProject(string projectId,int userId);
    
    }
}
