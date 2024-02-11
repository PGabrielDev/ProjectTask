namespace ProjectsTasks.Infrastruct.Database.Repository.Interfaces
{
    public interface IGetAll<T>
    {
        public ICollection<T> GetAll(); 
    }
}
