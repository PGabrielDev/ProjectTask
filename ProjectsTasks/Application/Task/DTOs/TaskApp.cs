using ProjectsTasks.Infrastruct.Database.entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectsTasks.Application.Task.DTOs
{
    public record TaskApp(int Id,
         int Priority,
         DateTime CreatedAt,
         DateTime UpdatedAt,
         ICollection<TaskDefinitionApp> TaskDefinitions,
         ICollection<HistoricOutput> historic
         )
    {
        public static TaskApp With(int Id,
        int Priority,
        DateTime CreatedAt,
        DateTime UpdatedAt,

        ICollection<TaskDefinitionApp> TaskDefinitions,
        ICollection<HistoricOutput> historic)
        {
            return new TaskApp(Id, Priority, CreatedAt, UpdatedAt, TaskDefinitions, historic);
        }
    }
}




