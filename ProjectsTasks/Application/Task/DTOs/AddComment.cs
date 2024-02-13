namespace ProjectsTasks.Application.Task.DTOs
{
    public record AddComment(int taskId, string comment, int userId, string email)
    {
        public static AddComment With(int taskId, string comment, int userId, string email = "")
        {
            return new AddComment(taskId, comment, userId, email);
        }
    }
}
