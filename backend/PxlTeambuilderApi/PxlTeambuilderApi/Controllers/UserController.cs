using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Services.Interfaces;

namespace PxlTeambuilderApi.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet]
        [Route("{userId}/projects")]
        public async Task<IActionResult> GetAllProjectsFromUser(int userId)
        {
            User user = await userService.GetUserByUserIdAsync(userId);
            List<Project> projects = new List<Project>();
            foreach(UserProjectDetail userProjectDetail in user.UserProjectDetails){
                projects.Add(userProjectDetail.Project);
            }

            return Ok(projects);
        }

    }
}