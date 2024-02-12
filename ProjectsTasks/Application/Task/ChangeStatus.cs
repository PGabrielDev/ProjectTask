using System.ComponentModel.DataAnnotations;

namespace ProjectsTasks.Application.Task
{
    public record ChangeStatus(int status, int taskId, string email)
    {
        public static ChangeStatus With(int status, int taskId, string email = "")
        {
            return new ChangeStatus(status, taskId, email);
        }
    }
    
}
