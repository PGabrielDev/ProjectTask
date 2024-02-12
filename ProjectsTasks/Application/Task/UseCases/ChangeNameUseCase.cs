using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.Task
{
    public class ChangeNameUseCase : UnitUseCase<ChangeName>
    {
        private readonly ITaskRepository taskRepository;

        public ChangeNameUseCase(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }
        public void Execute(ChangeName input)
        {
            var task = taskRepository.GetById(input.taskId);
            var taskDefinition = task.TaskDefinitions.LastOrDefault();

            var newTaskDefinition = new TaskDefinition
            {
                Assined = taskDefinition.Assined,
                AssinedId = taskDefinition.AssinedId,
                ChangeDescription = Mappers.CreateChangeDescription(input.email,"Alteracao de Nome",taskDefinition.Name,input.name),
                Comments = taskDefinition.Comments.Select(c => new Comment { CreatedAt = c.CreatedAt, TaskDefinitionId = 0, Text = c.Text, Userid = c.Userid }).ToList(),
                createdAt = DateTime.Now.ToUniversalTime(),
                Description = taskDefinition.Description,
                Name = input.name,
                Stats = taskDefinition.Stats,
                TaskId = taskDefinition.TaskId
            };
            taskRepository.Update(newTaskDefinition);   
        }
    }
}
