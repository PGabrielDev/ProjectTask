using ProjectsTasks.Application.Project.DTOs;


namespace ProjectsTasks.Test.Application.Project.DTOs
{
    public class ProjectOutputTest
    {
        [Fact]
        public void GivenAValidParametersWhenCallWithThenSuccess()
        {
            ProjectOutput project = ProjectOutput.With(1, "project", "descriptionProject", 1,DateTime.Now, new List<SimpleTask>());
            Assert.NotNull(project);
            Assert.IsType<ProjectOutput>(project);
        }

    }
}
