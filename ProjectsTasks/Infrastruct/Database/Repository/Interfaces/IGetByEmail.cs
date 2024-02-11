namespace ProjectsTasks.Infrastruct.Database.Repository.Interfaces
{
    public interface IGetByEmail<T>
    {
        public T? GetByEmail(string email);
    }
}
