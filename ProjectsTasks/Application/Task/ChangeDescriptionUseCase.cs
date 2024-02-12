using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.Task
{
    public class ChangeDescriptionUseCase : UnitUseCase<ChangeDescription>
    {
        private readonly ITaskRepository taskRepository;

        public ChangeDescriptionUseCase(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public void Execute(ChangeDescription input)
        {
            var task = taskRepository.GetById(input.taskId);
            var taskDefinition = task.TaskDefinitions.LastOrDefault();

            var newTaskDefinition = new TaskDefinition
            {
                Assined = taskDefinition.Assined,
                AssinedId = taskDefinition.AssinedId,
                ChangeDescription = Mappers.CreateChangeDescription(input.email,"Alteracao de Descrição", taskDefinition.Description, input.description),
                Comments = taskDefinition.Comments.Select(c => new Comment { CreatedAt = c.CreatedAt, TaskDefinitionId = 0, Text = c.Text, Userid = c.Userid }).ToList(),
                createdAt = DateTime.Now.ToUniversalTime(),
                Description = input.description,
                Name = taskDefinition.Name,
                Stats = taskDefinition.Stats,
                TaskId = taskDefinition.TaskId
            };
            taskRepository.Update(newTaskDefinition);
            
        }
    }
}
