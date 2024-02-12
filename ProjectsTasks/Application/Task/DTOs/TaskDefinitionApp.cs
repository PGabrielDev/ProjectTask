using ProjectsTasks.Infrastruct.Database.entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectsTasks.Application.Task.DTOs
{
    public record TaskDefinitionApp(
        int Id,
        string Name,
        string Description,
        int TaskId,
        int TaskStatus,
        DateTime Created,
        ICollection<CommentsApp> Comments,
        string ChangeDescription
        )
    {
        public static TaskDefinitionApp With(int Id,
       string Name,
       string Description,
       int TaskId,
       int TaskStatus,
       DateTime Created,
       ICollection<CommentsApp> Comments,
       string ChangeDescription)
        {
            return new TaskDefinitionApp(Id, Name, Description, TaskId, TaskStatus, Created, Comments, ChangeDescription);
        }
    }
}