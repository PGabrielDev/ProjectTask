namespace ProjectsTasks.Infrastruct.Database.Repository.Interfaces
{
    public interface IGetById<T>
    {
        public T? GetById(int id);
    }
}
