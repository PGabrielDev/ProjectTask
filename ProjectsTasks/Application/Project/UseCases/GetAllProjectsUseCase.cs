using ProjectsTasks.Application.Project.DTOs;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.Project.UseCases
{
    public class GetAllProjectsUseCase : NullaryUseCase<ICollection<ProjectOutput>>
    {
        private readonly IProjectRepository _repository;

        public GetAllProjectsUseCase(IProjectRepository repository)
        {
            _repository = repository;
        }

        public ICollection<ProjectOutput> Execute()
        {
            var projects = _repository.GetAll();
            return projects.Select(Mappers.FromProject).ToList();
        }
    }
}
