
namespace ProjectsTasks.Application.Task
{
    public record TaskDetailOutput(int id, string name, string description, int projectId,DateTime createdAt, DateTime updatedAt, string status, string priority,string assined ,ICollection<HistoricOutput> historic)
    {
        public static TaskDetailOutput With(int id, string name, string description, int projectId, DateTime createdAt, DateTime updatedAt, string status, string priority, string assined, ICollection<HistoricOutput> historic )
        {
            return new TaskDetailOutput(id, name, description, projectId, createdAt, updatedAt, status, priority, assined, historic);
        }
    }
}
