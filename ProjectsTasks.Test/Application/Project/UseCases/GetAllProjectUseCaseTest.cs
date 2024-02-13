using Moq;
using ProjectsTasks.Application.Project.DTOs;
using ProjectsTasks.Application.Project.UseCases;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
namespace ProjectsTasks.Test.Application.Project.UseCases
{
    
    public class GetAllProjectUseCaseTest
    {
        public GetAllProjectsUseCase useCase;
        public Mock<IProjectRepository> projectRepositoryMock;

        public GetAllProjectUseCaseTest()
        {
            projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(p => p.GetAll()).Returns(new List<ProjectsTasks.Infrastruct.Database.entities.Project>());
            useCase = new GetAllProjectsUseCase(projectRepositoryMock.Object);

        }

        [Fact]

        public void GivenAValidParametersWhenCallExecuteThenSuccess()
        {
            var teste = useCase.Execute();
            Assert.NotNull(teste);
            Assert.IsType<List<ProjectOutput>>(teste);
        }
    }
}
