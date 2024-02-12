using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.Task
{
    public class ChangeStatusTaskUseCase : UnitUseCase<ChangeStatus>
    {
        private ITaskRepository taskRepository;

        public ChangeStatusTaskUseCase(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        public void Execute(ChangeStatus input)
        {
            var task = taskRepository.GetById(input.taskId);
            var taskDefinition = task.TaskDefinitions.LastOrDefault();
            var newTaskDefinition = new TaskDefinition
            {
                Assined = taskDefinition.Assined,
                AssinedId = taskDefinition.AssinedId,
                ChangeDescription = Mappers.CreateChangeDescription(input.email,"Alteracao de Status",taskDefinition.Stats.ToString(),input.status.ToString()),
                Comments = taskDefinition.Comments.Select(c => new Comment { CreatedAt = c.CreatedAt, TaskDefinitionId = 0, Text = c.Text, Userid = c.Userid }).ToList(),
                createdAt = DateTime.Now.ToUniversalTime(),
                Description = taskDefinition.Description,
                Name = taskDefinition.Name,
                Stats = (Status) input.status,
                TaskId = taskDefinition.TaskId
            };
            taskRepository.Update(newTaskDefinition);
        }
    }

}
