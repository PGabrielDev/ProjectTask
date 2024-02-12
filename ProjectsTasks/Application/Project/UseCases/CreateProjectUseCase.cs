using ProjectsTasks.Application.Project.DTOs;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.Project.UseCases
{
    public class CreateProjectUseCase : UnitUseCase<CreateProject>
    {
        private IProjectRepository _repository;

        public CreateProjectUseCase(IProjectRepository repository)
        {
            _repository = repository;
        }

        public void Execute(CreateProject input)
        {
            var project = Mappers.FromProjectCreate(input);
            _repository.Save(project);
        }
    }
}
