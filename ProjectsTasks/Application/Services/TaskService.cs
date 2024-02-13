using ProjectsTasks.Application.Project.DTOs;
using ProjectsTasks.Application.Services.Interfaces;
using ProjectsTasks.Application.Task.DTOs;
using ProjectsTasks.Application.Task.UseCases;
using ProjectsTasks.Application.User.UseCases;

namespace ProjectsTasks.Application.Services
{
    public class TaskService : ITaskService 
    {
        private readonly CreateTaskUseCase createTaskUseCase;
        private readonly AddCommentUseCase addCommentUseCase;
        private readonly GetUserByEmailUseCase getUserByEmailUseCase;
        private readonly ChangeStatusTaskUseCase changeStatusTaskUseCase;
        private readonly ChangeDescriptionUseCase changeDescriptionUseCase;
        private readonly ChangeNameUseCase changeNameUseCase;
        private readonly RemoveTaskUseCase removeTaskUseCase;
        private readonly ChangeAssinedTaskUseCase changeAssinedTaskUseCase;
        private readonly GetTaskByIdUseCase getTaskByIdUseCase;
        private readonly GetTaskSimpleDetailsById getTaskSimpleDetailsById;
        private readonly GetReport30DaysUseCase getReport30DaysUseCase;
        public TaskService(
            CreateTaskUseCase createTaskUseCase,
            AddCommentUseCase addCommentUseCase,
            GetUserByEmailUseCase getUserByEmailUseCase,
            ChangeStatusTaskUseCase changeStatusTaskUseCase,
            ChangeDescriptionUseCase changeDescriptionUseCase,
            ChangeNameUseCase changeNameUseCase,
            RemoveTaskUseCase removeTaskUseCase,
            ChangeAssinedTaskUseCase changeAssinedTaskUseCase,
            GetTaskSimpleDetailsById getTaskDetailsUseCase,
            GetTaskByIdUseCase getTaskByIdUseCase,
            GetReport30DaysUseCase getReport30DaysUseCase)
        {
            this.createTaskUseCase = createTaskUseCase;
            this.addCommentUseCase = addCommentUseCase;
            this.getUserByEmailUseCase = getUserByEmailUseCase;
            this.changeStatusTaskUseCase = changeStatusTaskUseCase;
            this.changeDescriptionUseCase = changeDescriptionUseCase;
            this.changeNameUseCase = changeNameUseCase;
            this.removeTaskUseCase = removeTaskUseCase;
            this.changeAssinedTaskUseCase = changeAssinedTaskUseCase;
            this.getTaskSimpleDetailsById = getTaskDetailsUseCase;
            this.getTaskByIdUseCase = getTaskByIdUseCase;
            this.getReport30DaysUseCase = getReport30DaysUseCase;
        }

        public void AddComment(AddCommentInput comment, int taskId, string email)
        {
            var user = getUserByEmailUseCase.Execute(email);
            var commentAdd = Task.DTOs.AddComment.With( taskId, comment.comment,user.id, email);
            addCommentUseCase.Execute(commentAdd);
        }

        public void ChangeAssinedTask(int taskId, ChangeAssinedTaskInput input, string email = "")
        {
            var user = getUserByEmailUseCase.Execute(email);

            changeAssinedTaskUseCase.Execute(Task.DTOs.ChangeAssinedTask.With(taskId, input.assinedId, user.id, email));
        }

        public void ChangeDescription(int taskId, ChangeDescriptionInput input, string email = "")
        {
            var changeDescription = Task.DTOs.ChangeDescription.With(input.description, taskId);
            changeDescriptionUseCase.Execute(changeDescription);
        }

        public void ChangeNameTask(int taskId, ChangeNameInput changeNameInput , string email = "")
        {
            var changeName = ChangeName.With(taskId, changeNameInput.name, email);
            changeNameUseCase.Execute(changeName);
        }

        public void ChangeStatusTask(int taskId, ChangeStatusInput input, string email = "")
        {
            var status = ChangeStatus.With(input.status, taskId);
            changeStatusTaskUseCase.Execute(status);
        }

        public void CreateTask(CreateTask input)
        {
            createTaskUseCase.Execute(input);
        }

        public void DeleteTask(int taskId)
        {
            removeTaskUseCase.Execute(taskId);
        }

        public ICollection<ReportOutPut> GenerateReport()
        {
            return getReport30DaysUseCase.Execute();
        }

        public TaskApp GetTaskByIdCompleteHistoric(int taskId)
        {
            return getTaskByIdUseCase.Execute(taskId);
        }

        public TaskDetailOutput GetTaskByIdDetails(int taskId)
        {
            return getTaskSimpleDetailsById.Execute(taskId);
        }
    }
}
