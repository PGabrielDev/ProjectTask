using ProjectsTasks.Application.Project.DTOs;

namespace ProjectsTasks.Test.Application.Project.DTOs
{
    public class CreateProjectTest
    {
        [Fact]
        public void GivenAValidParametersWhenCallWithThenSuccess()
        {
            var projectName = "project teste";
            var projectDescription = "description teste";
            var userId = 1;

            var project = CreateProject.With(projectName, projectDescription, userId);

            Assert.NotNull(project);
            Assert.Equal(projectName, project.ProjectName);
            Assert.Equal(projectDescription, project.Description);
            Assert.Equal(userId, project.UserId);
            Assert.IsType<CreateProject>(project);
        }
    }
}
