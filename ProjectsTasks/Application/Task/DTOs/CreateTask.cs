namespace ProjectsTasks.Application.Task.DTOs
{
    public record CreateTask(int projectId, int priority, string name, string description, string email)
    {
        public static CreateTask With(int projectId, int priority, string name, string description, string email = "")
        {
            return new CreateTask(projectId, priority, name, description, email);
        }

    }
}
