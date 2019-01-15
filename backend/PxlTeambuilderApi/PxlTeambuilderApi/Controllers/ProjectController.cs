using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Data.Model;
using PxlTeambuilderApi.Exceptions;
using PxlTeambuilderApi.Services.Decorator;
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
            this.projectService = new LogDecorator(projectService);
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
        [Authorize]
        public async Task<IActionResult> GetAllGroupsByProjectId(string projectId)
        {
            try
            {
                ICollection<Group> groups = await projectService.GetGroupsFromProjectAsync(projectId);
                return Ok(groups);
            }

            catch(ProjectNotFoundException ex)
            {
                return BadRequest(ex.Message);
            }
           
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
        [Route("{projectId}/groups/new")]
        public async Task<IActionResult> AddNewGroup(string projectId,[FromBody] NewGroupInputModel inputModel)
        {
            try
            {
                bool success = await projectService.AddNewGroup(inputModel.UserId, projectId, inputModel.GroupName);
                if (!success)
                {
                    return BadRequest("something went wrong");
                }

                return Ok();
            }

            catch(UserAlreadyInProjectException)
            {
                return BadRequest("u are already participating in this project");
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("participate")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> ParticipateToProject([FromBody] ParticipateInputModel inputModel)
       {
            if (inputModel.GroupId == null | inputModel.ProjectId == null | inputModel.UserId == 0)
            {
                return BadRequest("missing data");
            }

            try
            {
                bool success = await projectService.AddUserToGroup(inputModel.UserId, inputModel.ProjectId, inputModel.GroupId);

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