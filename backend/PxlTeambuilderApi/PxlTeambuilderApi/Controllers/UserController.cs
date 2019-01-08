using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Data.Model;
using PxlTeambuilderApi.Exceptions;
using PxlTeambuilderApi.Services.Interfaces;
using PxlTeambuilderApi.Utility.JwtHelpers;

namespace PxlTeambuilderApi.Controllers
{
    [Produces("application/json")]
    [Route("api/users")]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IPasswordService passwordService;
        private readonly IConfiguration configuration;

        public UserController(IUserService userService, IPasswordService passwordService, IConfiguration configuration)
        {
            this.userService = userService;
            this.passwordService = passwordService;
            this.configuration = configuration;
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

        [HttpPost]
        [Route("login")]
        //TODO: add jwt token generation and pass to client.
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                User user = await userService.GetUserByEmail(loginModel.Email);
                if (passwordService.IsSame(loginModel.Password, user.Password))
                {
                    string role = user.Role.ToString();
                    var token = new JwtTokenBuilder()
                        .AddSecurityKey(JwtSecurityKey.Create(configuration.GetValue<string>("JwtSecretKey")))
                        .AddIssuer(configuration.GetValue<string>("JwtIssuer"))
                        .AddExpiry(1)
                        .AddClaim("Name", user.Name)
                        .AddRole(role)
                        .AddAudience(configuration.GetValue<string>("JwtAudience"))
                        .Build();

                    return Ok(new {token = token.Value});
                }

                return BadRequest();
            }

            catch (UserNotFoundException)
            {
                return BadRequest();
            }
        }

    }
}