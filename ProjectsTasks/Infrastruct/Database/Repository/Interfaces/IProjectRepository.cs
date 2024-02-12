using ProjectsTasks.Infrastruct.Database.entities;

namespace ProjectsTasks.Infrastruct.Database.Repository.Interfaces
{
    public interface IProjectRepository : BasicRepository<Project>, IDelete<Project>
    {
        ICollection<Project> GetAllProjectByUserId(int id);
    }
}
