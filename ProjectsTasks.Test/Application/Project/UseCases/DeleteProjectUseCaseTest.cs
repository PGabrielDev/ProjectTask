using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Moq;
using ProjectsTasks.Application.Project.DTOs;
using ProjectsTasks.Application.Project.UseCases;
using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Exceptions;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
namespace ProjectsTasks.Test.Application.Project.UseCases
{
    
    public class DeleteProjectUseCaseTest
    {
        public DeleteProjectUseCase useCase;
        public Mock<IProjectRepository> projectRepositoryMock;

        public DeleteProjectUseCaseTest()
        {
            projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(p => p.Delete(It.IsAny<int>(), It.IsAny<ProjectsTasks.Infrastruct.Database.entities.Project>())).Throws(new IncompleteProjectException("Tarefa: Tarefa 1"));
            useCase = new DeleteProjectUseCase(projectRepositoryMock.Object);

        }

        [Fact]

        public void GivenAValidParameterAndListTaskNotCompletesWhenCallExecuteThenReturnsFalse()
        {
            const int projectId = 1;

            Assert.Throws<IncompleteProjectException>(() =>
            {
                useCase.Execute(projectId);
            });
            projectRepositoryMock.Verify(x => x.Delete(It.IsAny<int>(), It.IsAny<ProjectsTasks.Infrastruct.Database.entities.Project>() ), Times.Exactly(1));
        }
    }
}
