using ProjectsTasks.Application.Project.DTOs;
using ProjectsTasks.Application.Task.DTOs;

namespace ProjectsTasks.Application.Services.Interfaces
{
    public interface ITaskService
    {
        public void CreateTask(CreateTask input);
        public void AddComment(AddCommentInput comment, int taskId, string email);

        public void ChangeStatusTask(int taskId, ChangeStatusInput input, string email = "");

        public void ChangeDescription(int taskId, ChangeDescriptionInput input , string email = "");

        public void ChangeAssinedTask(int taskId, ChangeAssinedTaskInput input, string email = "");

        public void ChangeNameTask(int taskIdm, ChangeNameInput changeNameInput, string email = "");

        public void DeleteTask(int taskId);

        public TaskApp GetTaskByIdCompleteHistoric(int taskId);

        public TaskDetailOutput GetTaskByIdDetails(int taskId);

        public ICollection<ReportOutPut> GenerateReport();
    }
}
