using Moq;
using ProjectsTasks.Application.Project.UseCases;
using ProjectsTasks.Application;
using ProjectsTasks.Infrastruct.Database.Exceptions;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectsTasks.Application.Project.DTOs;

namespace ProjectsTasks.Test.Application.Project.UseCases
{
    public class CreateProjectUseCaseTest
    {
        public CreateProjectUseCase useCase;
        public Mock<IProjectRepository> projectRepositoryMock;
        public CreateProjectUseCaseTest()
        {
            projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(p => p.Save(It.IsAny<ProjectsTasks.Infrastruct.Database.entities.Project>())).Returns(new ProjectsTasks.Infrastruct.Database.entities.Project {AuthorId = 1 });
            useCase = new CreateProjectUseCase(projectRepositoryMock.Object);
        }

        [Fact]
        public void GivenAValidParameterAndListTaskNotCompletesWhenCallExecuteThenReturnsSuccess()
        {
            var userId = 1;
            var project = CreateProject.With("project", "description", userId);

            useCase.Execute(project);
            projectRepositoryMock.Verify(x => x.Save(It.IsAny<ProjectsTasks.Infrastruct.Database.entities.Project>()), Times.Exactly(1));

        }
    }
}
