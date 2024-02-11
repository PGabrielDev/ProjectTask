using ProjectsTasks.Infrastruct.Database.DataAccess;
using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;

namespace ProjectsTasks.Infrastruct.Database.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly AppDbContext _context;

        public ProjectRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(int id, Project entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<Project> GetAll()
        {
            throw new NotImplementedException();
        }

        public Project? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Project Save(Project value)
        {
            _context.Projects.Add(value);
            _context.SaveChanges();
            return value;
        }

        public Project Update(Project entity)
        {
            throw new NotImplementedException();
        }
    }
}
