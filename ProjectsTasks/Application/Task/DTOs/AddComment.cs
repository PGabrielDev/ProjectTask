namespace ProjectsTasks.Application.Task.DTOs
{
    public record AddComment(int projectId, int taskId, string comment, int userId, string email)
    {
        public static AddComment With(int projectId, int taskId, string comment, int userId, string email = "")
        {
            return new AddComment(projectId, taskId, comment, userId, email);
        }
    }
}
