namespace ProjectsTasks.Infrastruct.Database.Repository.Interfaces
{
    public interface IDelete<T>
    {
        public void Delete(int id, T entity);
    }
}
