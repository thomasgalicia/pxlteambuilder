using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PxlTeambuilderApi.Controllers;
using PxlTeambuilderApi.Data.Domain;
using PxlTeambuilderApi.Data.Model;
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
        private Random random;
        private int userId;
        private string projectId;
        private string groupId;
        private ParticipateInputModel inputModel;

        private const string ERROR_MISSING_QUERYPARAM_MESSAGE = "missing data";
        private const string ERROR_ALREADY_PARTICIPATING_MESSAGE = "You are already participating in the project";
        private const string ERROR_GROUP_FULL_MESSAGE = "Group is full";

        [SetUp]
        public void Setup()
        {
            random = new Random();
            userId = random.Next();
            projectId = Guid.NewGuid().ToString();
            groupId = Guid.NewGuid().ToString();
            inputModel = new ParticipateInputModel
            {
                ProjectId = projectId,
                GroupId = groupId,
                UserId = userId
            };
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

        [Test]
        public void ParticipateToProjectShouldReturnBadRequestWithErrorMessageWhenNoUserIdIsPresent()
        {
            inputModel.UserId = 0;
            var result = projectController.ParticipateToProject(inputModel).Result as BadRequestObjectResult ;
            var errorMessage = (string)result.Value;

            Assert.NotNull(result);
            Assert.AreEqual(ERROR_MISSING_QUERYPARAM_MESSAGE, errorMessage);
            projectServiceMock.Verify(mock => mock.AddUserToGroup(0,projectId,groupId), Times.Never);
        }

        [Test]
        public void ParticipateToProjectShouldReturnBadRequestWithErrorMessageWhenNoProjectIdIsPresent()
        {
            inputModel.ProjectId = null;
            var result = projectController.ParticipateToProject(inputModel).Result as BadRequestObjectResult;
            var errorMessage = (string)result.Value;

            Assert.NotNull(result);
            Assert.AreEqual(ERROR_MISSING_QUERYPARAM_MESSAGE, errorMessage);
            projectServiceMock.Verify(mock => mock.AddUserToGroup(userId, projectId, groupId), Times.Never);
        }

        [Test]
        public void ParticipateToProjectShouldReturnBadRequestWithErrorMessageWhenNoGroupIdIsPresent()
        {
            inputModel.GroupId = null;
            var result = projectController.ParticipateToProject(inputModel).Result as BadRequestObjectResult;
            var errorMessage = (string)result.Value;

            Assert.NotNull(result);
            Assert.AreEqual(ERROR_MISSING_QUERYPARAM_MESSAGE, errorMessage);
            projectServiceMock.Verify(mock => mock.AddUserToGroup(userId, projectId, groupId), Times.Never);
        }

        [Test]
        public void ParticipateToProjectShouldReturnOkWhenAddedToGroupSuccessfullyInDatabase()
        {
            projectServiceMock.Setup(mock => mock.AddUserToGroup(userId, projectId, groupId)).ReturnsAsync(() => true);

            var result = projectController.ParticipateToProject(inputModel).Result as OkResult;

            Assert.NotNull(result);
            projectServiceMock.Verify(mock => mock.AddUserToGroup(userId, projectId, groupId), Times.Once);
        }

        [Test]
        public void ParticipateToProjectShouldReturnBadRequestWhenAddedToGroupFailedInDatabase()
        {
            projectServiceMock.Setup(mock => mock.AddUserToGroup(userId, projectId, groupId)).ReturnsAsync(false);

            var result = projectController.ParticipateToProject(inputModel).Result as BadRequestResult;

            Assert.NotNull(result);
            projectServiceMock.Verify(mock => mock.AddUserToGroup(userId, projectId, groupId), Times.Once);
        }

        [Test]
        public void ParticipateToProjectShouldReturnBadRequestWhenUserAlreadyInProjectExceptionOccurs()
        {
            projectServiceMock.Setup(mock => mock.AddUserToGroup(userId, projectId, groupId)).Throws<UserAlreadyInProjectException>();

            var result = projectController.ParticipateToProject(inputModel).Result as BadRequestObjectResult;
            var errorMessage = (string)result.Value;

            Assert.NotNull(result);
            Assert.AreEqual(ERROR_ALREADY_PARTICIPATING_MESSAGE, errorMessage);
            projectServiceMock.Verify(mock => mock.AddUserToGroup(userId, projectId, groupId), Times.Once);

        }

        [Test]
        public void ParticipateToProjectShouldReturnBadRequestWhenMaxStudentsBoundsExceptionOccurs()
        {
            projectServiceMock.Setup(mock => mock.AddUserToGroup(userId, projectId, groupId)).Throws<MaxStudentsBoundsException>();

            var result = projectController.ParticipateToProject(inputModel).Result as BadRequestObjectResult;
            var errorMessage = (string)result.Value;

            Assert.NotNull(result);
            Assert.AreEqual(ERROR_GROUP_FULL_MESSAGE, errorMessage);
            projectServiceMock.Verify(mock => mock.AddUserToGroup(userId, projectId, groupId), Times.Once);
        }
    }
}
