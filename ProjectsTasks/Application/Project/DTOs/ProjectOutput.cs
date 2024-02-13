namespace ProjectsTasks.Application.Project.DTOs
{
    public record ProjectOutput(int id, string name, string description, int authorId, DateTime createdAt, ICollection<SimpleTask> tasks)
    {
        public static ProjectOutput With(int id, string name, string description, int authorId, DateTime createdAt, ICollection<SimpleTask> tasks)
        {
            return new ProjectOutput(id, name, description, authorId, createdAt, tasks);
        }
    }
}
