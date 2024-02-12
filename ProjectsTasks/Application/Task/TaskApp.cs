using ProjectsTasks.Infrastruct.Database.entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectsTasks.Application.Task
{
    public record TaskApp(int Id,
         int Priority,
         DateTime CreatedAt,
         DateTime UpdatedAt,

         ICollection<TaskDefinitionApp> TaskDefinitions)
    {
         public static TaskApp With(int Id,
         int Priority,
         DateTime CreatedAt,
         DateTime UpdatedAt,

         ICollection<TaskDefinitionApp> TaskDefinitions)
        {
            return new TaskApp(Id, Priority, CreatedAt, UpdatedAt, TaskDefinitions);
        }
    }
}




