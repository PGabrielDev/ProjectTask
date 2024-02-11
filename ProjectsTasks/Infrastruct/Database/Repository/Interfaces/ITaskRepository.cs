
using ProjectsTasks.Infrastruct.Database.DataAccess;
using ProjectsTasks.Infrastruct.Database.entities;

namespace ProjectsTasks.Infrastruct.Database.Repository.Interfaces
{
    public interface ITaskRepository : CrudRepository<entities.Task>
    {
        
    }
}
