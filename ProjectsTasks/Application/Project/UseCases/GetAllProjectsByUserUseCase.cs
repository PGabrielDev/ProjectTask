using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.Project
{
    public class GetAllProjectsByUserUseCase : UseCase<int, ICollection<ProjectOutput>>
    {
        private readonly IProjectRepository projectRepository;

        public GetAllProjectsByUserUseCase(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public ICollection<ProjectOutput> Execute(int input)
        {
            var projects = projectRepository.GetAllProjectByUserId(input);
            return projects.Select(Mappers.FromProject).ToList();
        }
    }
}
