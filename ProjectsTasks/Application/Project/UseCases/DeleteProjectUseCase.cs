using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;

namespace ProjectsTasks.Application.Project
{
    public class DeleteProjectUseCase : UnitUseCase<int>
    {
        private readonly IProjectRepository projectRepository;

        public DeleteProjectUseCase(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public void Execute(int input)
        {
            projectRepository.Delete(input, new Infrastruct.Database.entities.Project { Id = input });
        }
    }
}
