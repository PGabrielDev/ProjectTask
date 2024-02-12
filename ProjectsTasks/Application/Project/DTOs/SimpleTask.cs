namespace ProjectsTasks.Application.Project.DTOs
{
    public record SimpleTask(int id, string name, string description, DateTime createdAt, DateTime updatedAt, string status, string priority, string assined)
    {
        public static SimpleTask With(int id, string name, string description, DateTime createdAt, DateTime updatedAt, string status, string priority, string assined)
        {
            return new SimpleTask(id, name, description, createdAt, updatedAt, status, priority, assined);
        }
    }
}
