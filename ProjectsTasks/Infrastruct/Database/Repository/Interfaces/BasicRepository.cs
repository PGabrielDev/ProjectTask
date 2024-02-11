namespace ProjectsTasks.Infrastruct.Database.Repository.Interfaces
{
    public interface BasicRepository<T> : ISave<T>, IGetById<T>, IGetAll<T> 
    {

    }
}
