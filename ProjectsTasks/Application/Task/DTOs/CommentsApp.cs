using ProjectsTasks.Infrastruct.Database.entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectsTasks.Application.Task
{
    public record CommentsApp(int Id, string Text, int UserId, int TaskDefinitionId, DateTime CreatedAt)
    {
         public static CommentsApp With(int Id, string Text, int UserId, int TaskDefinitionId, DateTime CreatedAt)
        {
            return new CommentsApp(Id, Text, UserId, TaskDefinitionId, CreatedAt);
        }
    }
}