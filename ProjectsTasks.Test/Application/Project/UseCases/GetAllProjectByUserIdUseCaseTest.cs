using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Moq;
using ProjectsTasks.Application.Project.DTOs;
using ProjectsTasks.Application.Project.UseCases;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
namespace ProjectsTasks.Test.Application.Project.UseCases
{
    
    public class GetAllProjectByUserIdUseCaseTest
    {
        public GetAllProjectsByUserUseCase useCase;
        public Mock<IProjectRepository> projectRepositoryMock;

        public GetAllProjectByUserIdUseCaseTest()
        {
            projectRepositoryMock = new Mock<IProjectRepository>();
            projectRepositoryMock.Setup(p => p.GetAllProjectByUserId(It.IsAny<int>())).Returns(new List<ProjectsTasks.Infrastruct.Database.entities.Project>() { new Infrastruct.Database.entities.Project { AuthorId = 1 } });
            useCase = new GetAllProjectsByUserUseCase(projectRepositoryMock.Object);

        }

        [Fact]

        public void GivenAValidParametersWhenCallExecuteThenSuccess()
        {
            const int userId = 1;
            var result = useCase.Execute(userId);
            Assert.NotNull(result);
            foreach (var project in result)
            {
                Assert.Equal(userId, project.authorId);
            }
            Assert.IsType<List<ProjectOutput>>(result);
            projectRepositoryMock.Verify(x => x.GetAllProjectByUserId(userId), Times.Exactly(1));
        }
    }
}
