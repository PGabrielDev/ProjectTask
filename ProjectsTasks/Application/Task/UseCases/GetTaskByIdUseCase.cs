using ProjectsTasks.Application.Task.DTOs;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.Task.UseCases
{
    public class GetTaskByIdUseCase : UseCase<int, TaskApp>
    {
        private readonly ITaskRepository taskRepository;
        public GetTaskByIdUseCase(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public TaskApp Execute(int id)
        {
            var task = taskRepository.GetById(id);
            return Mappers.FromTaskComplete(task);
        }
    }
}
