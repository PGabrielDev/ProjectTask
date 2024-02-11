using ProjectsTasks.Application.Task;

namespace ProjectsTasks.Application.Services.Interfaces
{
    public interface ITaskService
    {
        public void CreateTask(CreateTask input);
    }
}
