namespace ProjectsTasks.Application.Task
{
    public record ChangeName(int taskId, string name, string email)
    {
        public static ChangeName With(int taskId, string name, string email = "")
        {
            return new ChangeName(taskId, name, email);
        }
    }
}
