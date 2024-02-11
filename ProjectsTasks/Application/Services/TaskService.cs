using ProjectsTasks.Application.Services.Interfaces;
using ProjectsTasks.Application.Task;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;

namespace ProjectsTasks.Application.Services
{
    public class TaskService : ITaskService
    {
        private CreateTaskUseCase createTaskUseCase;

        public TaskService(CreateTaskUseCase createTaskUseCase)
        {
            this.createTaskUseCase = createTaskUseCase;
        }

        public void CreateTask(CreateTask input)
        {
            createTaskUseCase.Execute(input);
        }
    }
}
