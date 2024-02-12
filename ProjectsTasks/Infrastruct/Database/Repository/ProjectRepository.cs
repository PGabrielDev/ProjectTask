using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ProjectsTasks.Infrastruct.Database.DataAccess;
using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Exceptions;
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
           var project = _context.Projects
                .Include(p => p.Tasks)
                .ThenInclude(t => t.TaskDefinitions)
                .FirstOrDefault(p => p.Id == id);

            if (project != null)
            {
                if (project.Tasks != null && project.Tasks.Count() > 0)
                {
                    var tasks = project.Tasks;
                    var completed = new List<String>();
                    foreach (var task in tasks)
                    {
                        var tf = task.TaskDefinitions.LastOrDefault();
                        if ((int)tf.Stats != 2)
                        {
                            completed.Add($"Tarefa: ${tf.Name}");
                        }
                    }
                    if (completed.Count() > 0)
                    {
                        throw new IncompleteProjectException(string.Join(";", completed));
                    }
                }

                _context.Entry(project).State = EntityState.Detached;
                _context.Projects.Remove(entity);
                _context.SaveChanges();
            }
        }

        public ICollection<Project> GetAll()
        {
            return _context.Projects
                .Include(p => p.Tasks)
                .ThenInclude(t => t.TaskDefinitions)
                .ThenInclude(tf => tf.Assined)
                .ToList();
        }

        public ICollection<Project> GetAllProjectByUserId(int id)
        {
            return _context.Projects
                .Include(p => p.Tasks)
                .ThenInclude(t => t.TaskDefinitions)
                .ThenInclude(tf => tf.Assined)
                .Where(p => p.AuthorId == id)
                .ToList();
        }

        public Project? GetById(int id)
        {
            var project = _context.Projects
                .Include(p => p.Tasks)
                .ThenInclude(t => t.TaskDefinitions)
                .ThenInclude(tf => tf.Comments)
                .FirstOrDefault(p => p.Id == id);
            
            return project;
        }

        public Project Save(Project value)
        {
            _context.Projects.Add(value);
            _context.SaveChanges();
            return value;
        }

    }
}
