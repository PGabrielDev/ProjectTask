using ProjectsTasks.Application.Task.DTOs;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.Task.UseCases
{
    public class CreateTaskUseCase : UnitUseCase<CreateTask>
    {
        private readonly ITaskRepository taskRepository;

        public CreateTaskUseCase(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public void Execute(CreateTask input)
        {
            var task = Mappers.FromTaskCreate(input);
            taskRepository.Save(task);

        }
    }
}
