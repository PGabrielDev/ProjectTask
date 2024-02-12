using ProjectsTasks.Application.Project;
using ProjectsTasks.Application.Services.Interfaces;
using ProjectsTasks.Application.User;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly GetUserByEmailUseCase getUserByEmailUseCase;
        private readonly DeleteProjectUseCase deleteProjectUseCase;
        private readonly CreateProjectUseCase createProjectUseCase;
        private readonly GetAllProjectsUseCase getAllProjectsUseCase;
        private readonly GetAllProjectsByUserUseCase getAllProjectsByUserUseCase;
        public ProjectService(
            GetUserByEmailUseCase getUserByEmailUseCase,
            DeleteProjectUseCase deleteProjectUseCase,
            CreateProjectUseCase createProjectUseCase, 
            GetAllProjectsUseCase getAllProjectsUseCase,
            GetAllProjectsByUserUseCase getAllProjectsByUserUseCase
            )
        {
            this.getUserByEmailUseCase = getUserByEmailUseCase;
            this.deleteProjectUseCase = deleteProjectUseCase;
            this.createProjectUseCase = createProjectUseCase;
            this.getAllProjectsUseCase = getAllProjectsUseCase;
            this.getAllProjectsByUserUseCase = getAllProjectsByUserUseCase;
        }

        public void CreateProject(CreateProjectInput input, string email)
        {
            var user = getUserByEmailUseCase.Execute(email);

            var project = Project.CreateProject.With(input.ProjectName, input.Description, user.id);
            
            createProjectUseCase.Execute(project);
            
        }

        public void DeleteProject(int projectId)
        {
            deleteProjectUseCase.Execute(projectId);
        }

        public ICollection<ProjectOutput> GetProjects()
        {
            return getAllProjectsUseCase.Execute();
        }

        public ICollection<ProjectOutput> GetProjectsByUserID(int userId)
        {
            return getAllProjectsByUserUseCase.Execute(userId);
        }
    }
}
