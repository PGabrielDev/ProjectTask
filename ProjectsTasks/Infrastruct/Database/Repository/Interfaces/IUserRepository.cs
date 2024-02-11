using ProjectsTasks.Infrastruct.Database.entities;

namespace ProjectsTasks.Infrastruct.Database.Repository.Interfaces
{
    public interface IUserRepository : CrudRepository<User>, IGetByEmail<User>
    {
    }
}
