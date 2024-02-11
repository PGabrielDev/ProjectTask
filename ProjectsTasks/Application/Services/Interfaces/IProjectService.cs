using ProjectsTasks.Application.Project;

namespace ProjectsTasks.Application.Services.Interfaces
{
    public interface IProjectService
    {
        public void CreateProject(CreateProjectInput input);
    }
}
