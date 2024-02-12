using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;

namespace ProjectsTasks.Application.Task
{
    public class RemoveTaskUseCase : UnitUseCase<int>
    {
        private readonly ITaskRepository taskRepository;

        public RemoveTaskUseCase(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public void Execute(int input)
        {
            taskRepository.Delete(input, new Infrastruct.Database.entities.Task {  Id = input });
        }
    }
}
