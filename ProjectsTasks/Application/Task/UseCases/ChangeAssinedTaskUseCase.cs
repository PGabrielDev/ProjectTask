using ProjectsTasks.Application.Task.DTOs;
using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.Task.UseCases
{
    public class ChangeAssinedTaskUseCase : UnitUseCase<ChangeAssinedTask>
    {
        private readonly ITaskRepository taskRepository;

        public ChangeAssinedTaskUseCase(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public void Execute(ChangeAssinedTask input)
        {
            var task = taskRepository.GetById(input.taskId);
            var taskDefinition = task.TaskDefinitions.LastOrDefault();
            string changeDescription = input.assinedId == input.userId
                ? $"User: {input.userId} atribuiu a tarefa a ele mesmo; Alterado por {input.email} em {DateTime.Now} "
                : $"User: {input.userId} atribuiu a tarefa a {input.assinedId}; Alterado por {input.email} em {DateTime.Now}";
            var newTaskDefinition = new TaskDefinition
            {

                AssinedId = input.assinedId,
                ChangeDescription = changeDescription,
                Comments = taskDefinition.Comments.Select(c => new Comment { CreatedAt = c.CreatedAt, TaskDefinitionId = 0, Text = c.Text, Userid = c.Userid }).ToList(),
                createdAt = DateTime.Now.ToUniversalTime(),
                Description = taskDefinition.Description,
                Name = taskDefinition.Name,
                Stats = taskDefinition.Stats,
                TaskId = taskDefinition.TaskId
            };
            taskRepository.Update(newTaskDefinition);
        }
    }
}
