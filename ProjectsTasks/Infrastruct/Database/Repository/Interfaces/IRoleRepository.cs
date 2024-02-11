using ProjectsTasks.Infrastruct.Database.entities;

namespace ProjectsTasks.Infrastruct.Database.Repository.Interfaces
{
    public interface IRoleRepository : IGetAll<Role>, ISave<Role>
    {
        ICollection<Role> GetUsersDefaultRole();
    }
}
