using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PxlTeambuilderApi.Controllers;
using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Exceptions;
using PxlTeambuilderApi.Services.Interfaces;
using PxlTeambuilderApi.Tests.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PxlTeambuilderApi.Tests.Controllers
{
    [TestFixture]
    public class ProjectControllerTests
    {

        private ProjectController projectController;
        private Mock<IProjectService> projectServiceMock;
        private ProjectBuilder projectBuilder;

        [SetUp]
        public void Setup()
        { 
            projectBuilder = new ProjectBuilder();
            projectServiceMock = new Mock<IProjectService>();
            projectController = new ProjectController(projectServiceMock.Object);
        }

        [Test]
        public void GetProjectShouldThrowProjectNotFoundExceptionWhenProjectDoesNotExist()
        {
            string projectId = Guid.NewGuid().ToString();
            string expectedErrorMessage = $"project with id:{projectId} was not found";
            projectServiceMock.Setup(mock => mock.GetProjectByIdAsync(projectId)).Throws(new ProjectNotFoundException(projectId));

            var result = projectController.GetProject(projectId).Result as NotFoundObjectResult;
            var message = (string) result.Value;

            Assert.NotNull(result);
            Assert.AreEqual(message, expectedErrorMessage);
            projectServiceMock.Verify(mock => mock.GetProjectByIdAsync(projectId), Times.Once);
        }

        [Test]
        public void GetProjectShouldReturnOkResultWithProjectInBodyWhenProjectExists()
        {
            string projectId = Guid.NewGuid().ToString();
            string title = Guid.NewGuid().ToString();
            Project project = projectBuilder.WithProjectId(projectId).WithTitle(title).Build();

            projectServiceMock.Setup(mock => mock.GetProjectByIdAsync(projectId)).ReturnsAsync(project);

            var result = projectController.GetProject(projectId).Result as OkObjectResult;
            var responseBody = (Project)result.Value;

            Assert.NotNull(result);
            Assert.AreEqual(project, responseBody);
            projectServiceMock.Verify(mock => mock.GetProjectByIdAsync(projectId), Times.Once);
        }

        [Test]
        public void AddNewProjectShouldReturnBadRequestWhenNoEntityIsInsertedInDatabase()
        {
            Project project = projectBuilder.Build();
            projectServiceMock.Setup(mock => mock.AddProjectAsync(project)).ReturnsAsync(() => null);

            var result = projectController.AddNewProject(project).Result as BadRequestResult;

            Assert.NotNull(result);
            projectServiceMock.Verify(mock => mock.AddProjectAsync(project), Times.Once);
        }

        [Test]
        public void AddNewProjectShouldReturnCreatedWhenEntityIsSuccesfullyInsertedInDatabase()
        {
            Project project = projectBuilder.WithTitle(Guid.NewGuid().ToString()).Build();
            projectServiceMock.Setup(mock => mock.AddProjectAsync(project)).ReturnsAsync(project);

            var result = projectController.AddNewProject(project).Result as StatusCodeResult;
            var responseCode = result.StatusCode;

            Assert.NotNull(result);
            Assert.AreEqual(201, responseCode);
            projectServiceMock.Verify(mock => mock.AddProjectAsync(project), Times.Once);
        }
    }
}
