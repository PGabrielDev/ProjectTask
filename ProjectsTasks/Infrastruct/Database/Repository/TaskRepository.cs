using ProjectsTasks.Infrastruct.Database.DataAccess;

namespace ProjectsTasks.Infrastruct.Database.Repository.Interfaces
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _context;

        public TaskRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(int id, entities.Task entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<entities.Task> GetAll()
        {
            throw new NotImplementedException();
        }

        public entities.Task? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public entities.Task Save(entities.Task value)
        {
            _context.Tasks.Add(value);
            _context.SaveChanges();
            return value;
        }

        public entities.Task Update(entities.Task entity)
        {
            throw new NotImplementedException();
        }
    }
}
