using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PxlTeambuilderApi.Controllers;
using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Services.Interfaces;
using PxlTeambuilderApi.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Tests.Controllers
{
    [TestFixture]
    class UserControllerTests
    {

        private UserController userController;
        private Mock<IUserService> userServiceMock;
        private Random random;
        private ProjectBuilder projectBuilder;

        [SetUp]
        public void Setup()
        {
            userServiceMock = new Mock<IUserService>();
            random = new Random();
            projectBuilder = new ProjectBuilder();
            userController = new UserController(userServiceMock.Object);
        }


        [Test]
        public void GetAllProjectsFromUserShouldReturnOKWithEmptyListIfUserHasNoProjects()
        {
            int userId = random.Next();
            ICollection<Project> projects = new List<Project>();
           
            User user = new User();
            user.Projects = projects;
            
            userServiceMock.Setup(mock => mock.GetUserByUserIdAsync(userId)).ReturnsAsync(user);

            var result = userController.GetAllProjectsFromUser(userId).Result as OkObjectResult;
            var responseList = (ICollection<Project>) result.Value;

            Assert.NotNull(result);
            Assert.AreEqual(projects.Count, responseList.Count);
            userServiceMock.Verify(mock => mock.GetUserByUserIdAsync(userId), Times.Once);
        }

        [Test]
        public void GetAllProjectsFromUserShouldReturnOKWithProjectListIfUserHasProjects()
        {
            int userId = random.Next();
            ICollection<Project> projects = new List<Project>();
            projects.Add(projectBuilder.WithUserId(userId).Build());

            User user = new User();
            user.Projects = projects;

            userServiceMock.Setup(mock => mock.GetUserByUserIdAsync(userId)).ReturnsAsync(user);

            var result = userController.GetAllProjectsFromUser(userId).Result as OkObjectResult;
            var responseList = (ICollection<Project>) result.Value;

            Assert.NotNull(result);
            Assert.AreEqual(projects, responseList);
            userServiceMock.Verify(mock => mock.GetUserByUserIdAsync(userId), Times.Once);
        }
    }
}
