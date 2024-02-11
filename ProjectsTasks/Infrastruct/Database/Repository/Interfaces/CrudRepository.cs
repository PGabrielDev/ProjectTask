
namespace ProjectsTasks.Infrastruct.Database.Repository.Interfaces
{
    public interface CrudRepository<T> : IDelete<T>, IUpdate<T>, IGetAll<T>, IGetById<T>, ISave<T>
    {

    }
}
