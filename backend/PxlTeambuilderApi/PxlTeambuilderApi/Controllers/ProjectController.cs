﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Exceptions;
using PxlTeambuilderApi.Services.Interfaces;

namespace PxlTeambuilderApi.Controllers
{
    [Produces("application/json")]
    [Route("api/projects")]
    public class ProjectController : Controller
    {
        private readonly IProjectService projectService;
        private const string ROLE_CLAIM_TYPE = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role";

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet]
        [Route("{projectId}")]
        public async Task<IActionResult> GetProject(string projectId)
        {
            try
            {
                Project project = await projectService.GetProjectByIdAsync(projectId);
                return Ok(project);
            }

            catch(ProjectNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("user/{userId}")]
        [Authorize]
        public IActionResult GetAllProjectsByUserId(int userId)
        {
            Claim roleClaim = HttpContext.User.Claims.Where(claim => claim.Type == ROLE_CLAIM_TYPE).First();
            ICollection<Project> projects = projectService.GetAllProjectsByUserId(userId, roleClaim.Value);
            return Ok(projects);
        }

        [HttpGet]
        [Route("{projectId}/groups")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> GetAllGroupsByProjectId(string projectId)
        {
            ICollection<Group> groups = await projectService.GetGroupsFromProjectAsync(projectId);
            return Ok(groups);
        }

        [HttpPost]
        [Route("new")]
        [Authorize(Roles = "Teacher")]
        public async Task<IActionResult> AddNewProject([FromBody] Project project)
        {
            Project insertedEntity = await projectService.AddProjectAsync(project);
            if(insertedEntity == null)
            {
                return BadRequest();
            }

            return StatusCode(201);
        }

       [HttpPost]
       [Route("participate")]
       public async Task<IActionResult> ParticipateToProject([FromQuery(Name = "uid")] int userId,[FromQuery(Name = "pid")] string projectId,[FromQuery(Name = "gid")] string groupId)
        {
            if(userId == 0 | projectId == null | groupId == null)
            {
                return BadRequest("missing query parameter(s)");
            }

            try
            {
                bool success = await projectService.AddUserToGroup(userId, projectId, groupId);

                if (success)
                {
                    return Ok();
                }

                return BadRequest();
            }

            catch (UserAlreadyInProjectException)
            {
                return BadRequest("You are already participating in the project");
            }

            catch (MaxStudentsBoundsException)
            {
                return BadRequest("Group is full");
            }
  
        }
    }
}