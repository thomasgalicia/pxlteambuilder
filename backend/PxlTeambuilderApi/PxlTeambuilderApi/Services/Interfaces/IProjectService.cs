﻿using PxlTeambuilderApi.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PxlTeambuilderApi.Services.Interfaces
{
    public interface IProjectService
    {
        ICollection<Project> GetAllProjectsByUserId(int userId, string role);
        Task<Project> GetProjectByIdAsync(string projectId);
        Task<ICollection<Group>> GetGroupsFromProjectAsync(string projectId);
        Task<Project> AddProjectAsync(Project project);
        Task<Project> UpdateProjectAsync(string projectId, Project project);
        Task<bool> AddUserToGroup(int userId,string projectId,string groupId);
    }
}
