namespace ProjectsTasks.Infrastruct.Database.Repository.Interfaces
{
    public interface IUpdate<T>
    {
        public T Update(T entity);
    }
}
