namespace ProjectsTasks.Application.Task
{
    public record ChangeAssinedTask(int taskId, int assinedId, int userId, string email)
    {
        public static ChangeAssinedTask With(int taskId, int assinedId, int userId, string email = "")
        { 
            return new ChangeAssinedTask(taskId, assinedId, userId, email);
        }
    }
}
