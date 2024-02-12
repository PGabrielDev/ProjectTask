using Npgsql.TypeMapping;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;

namespace ProjectsTasks.Application.Task
{
    public class GetTaskDetailsUseCase : UseCase<int, string>
    {
        private readonly ITaskRepository taskRepository;

        public GetTaskDetailsUseCase(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public string Execute(int input)
        {



            return "";
        }
    }
}
