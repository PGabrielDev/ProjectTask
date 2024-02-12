using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.Task
{
    public class AddCommentUseCase : UnitUseCase<AddComment>
    {
        private ITaskRepository taskRepository;

        public AddCommentUseCase(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public void Execute(AddComment input)
        {
            var task = taskRepository.GetById(input.taskId);
            var taskDefinition = task.TaskDefinitions.LastOrDefault();
            var newTaskDefinition = new TaskDefinition
            {
                Assined = taskDefinition.Assined,
                AssinedId = taskDefinition.AssinedId,
                ChangeDescription = $"Comentario Adicionado: {input.comment}; Por: {input.email} em {DateTime.Now}",
                Comments = taskDefinition.Comments.Select(c => new Comment { CreatedAt = c.CreatedAt, TaskDefinitionId = 0, Text = c.Text, Userid = c.Userid}).ToList(),
                createdAt = DateTime.Now.ToUniversalTime(),
                Description = taskDefinition.Description,
                Name = taskDefinition.Name,
                Stats = taskDefinition.Stats,
                TaskId = taskDefinition.TaskId
            };
            newTaskDefinition.Comments.Add(Mappers.FromAddComment(input) );
            taskRepository.Update(newTaskDefinition);
        }
    }
}
