namespace ProjectsTasks.Infrastruct.Database.Repository.Interfaces
{
    public interface ISave<T>
    {
        public T Save(T value);
    }
} 
