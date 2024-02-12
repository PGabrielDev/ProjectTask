using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;
using System.Reflection.Metadata.Ecma335;

namespace ProjectsTasks.Application.Task
{
    public class GetTaskSimpleDetailsById : UseCase<int, TaskDetailOutput>
    {
        private ITaskRepository taskRepository;

        public GetTaskSimpleDetailsById(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public TaskDetailOutput Execute(int input)
        {
            return Mappers.FromTaskDetails(taskRepository.GetById(input));
        }
    }
}
