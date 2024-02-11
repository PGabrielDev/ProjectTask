using ProjectsTasks.Application.Project;
using ProjectsTasks.Application.Services.Interfaces;
using ProjectsTasks.Application.User;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;
        private readonly GetUserByEmailUseCase getUserByEmailUseCase;
        public ProjectService(IProjectRepository projectRepository, GetUserByEmailUseCase getUserByEmailUseCase)
        {
            this.projectRepository = projectRepository;
            this.getUserByEmailUseCase = getUserByEmailUseCase;
        }

        public void CreateProject(CreateProjectInput input)
        {
            var user = getUserByEmailUseCase.Execute(input.email);

            var project = Project.CreateProject.With(input.ProjectName, input.Description, user.id);
            
            var projectEntity = Mappers.FromProjectCreate(project);
            
            projectRepository.Save(projectEntity);
            
        }
    }
}
