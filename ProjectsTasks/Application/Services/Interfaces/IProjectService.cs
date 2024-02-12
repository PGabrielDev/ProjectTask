using ProjectsTasks.Application.Project;

namespace ProjectsTasks.Application.Services.Interfaces
{
    public interface IProjectService
    {
        public void CreateProject(CreateProjectInput input, string email);
        public void DeleteProject(int projectId);

        public ICollection<ProjectOutput> GetProjects();
        public ICollection<ProjectOutput> GetProjectsByUserID(int userId);

    }
}
