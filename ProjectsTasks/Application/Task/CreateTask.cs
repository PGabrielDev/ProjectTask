namespace ProjectsTasks.Application.Task
{
    public record CreateTask(int projectId, int priority, string name, string description)
    {
        public static CreateTask With(int projectId, int priority, string name, string description)
        {
            return new CreateTask(projectId, priority, name, description);
        }

    }
}
