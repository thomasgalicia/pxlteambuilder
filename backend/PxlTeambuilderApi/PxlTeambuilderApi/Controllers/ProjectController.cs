using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpPost]
        [Route("new")]
        public async Task<IActionResult> AddNewProject([FromBody] Project project)
        {
            Project insertedEntity = await projectService.AddProjectAsync(project);
            if(insertedEntity == null)
            {
                return BadRequest();
            }

            return StatusCode(201);
        }
    }
}