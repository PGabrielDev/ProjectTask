namespace ProjectsTasks.Application.Project
{
    public record ProjectOutput(int id, string name, string description, DateTime createdAt, ICollection<SimpleTask> tasks)
    {
        public static ProjectOutput With(int id, string name, string description, DateTime createdAt, ICollection<SimpleTask> tasks)
        {
            return new ProjectOutput(id, name, description, createdAt, tasks);
        }
    }
}
