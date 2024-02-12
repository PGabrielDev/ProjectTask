using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using ProjectsTasks.Infrastruct.Database.DataAccess;
using ProjectsTasks.Infrastruct.Database.entities;
using System.Data;
using System.Threading.Tasks;

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
            var result = _context.Tasks.FirstOrDefault(t => t.Id == id);
            if (result != null)
            {
                _context.Entry(result).State = EntityState.Detached;
                _context.Tasks.Remove(entity);
                _context.SaveChanges();
            }
        }

        public ICollection<entities.Task> GetAll()
        {
            var result = _context.Tasks
                .Include(t => t.TaskDefinitions)
                .ThenInclude(tf => tf.Comments)
                .ToList();
            return result;
        }

        public ICollection<entities.Task> GetAllTask30Days()
        {
            var result = _context.Tasks
            .Include(t => t.TaskDefinitions)
            .ThenInclude(t => t.Assined)
            .Where(t => t.TaskDefinitions.Any(td => td.Stats == Status.DONE && td.createdAt >= DateTime.Now.ToUniversalTime().AddDays(-30) && td.AssinedId != null && td.AssinedId != 0))
            .ToList();
            return result;
        }

        public entities.Task? GetById(int id)
        {
            var result = _context.Tasks
                .Include(t => t.TaskDefinitions)
                    .ThenInclude(t => t.Assined)
                .Include(t => t.TaskDefinitions)
                    .ThenInclude(tf => tf.Comments)

                .FirstOrDefault(t => t.Id == id);
            return result;
        }
        public entities.Task Save(entities.Task value)
        {
            var project = _context.Projects
                .Include(p => p.Tasks)
                .FirstOrDefault(p => p.Id == value.ProjectId);

            if (project.Tasks.Count() >= 20)
            {
                throw new Exceptions.LimitTaskException();
            }

            _context.Tasks.Add(value);
            _context.SaveChanges();
            return value;
        }

        TaskDefinition IUpdate<TaskDefinition>.Update(TaskDefinition task)
        {
            var result = _context.Tasks
                .Include(t => t.TaskDefinitions)
                .ThenInclude(tf => tf.Comments)
                .FirstOrDefault(t => t.Id == task.TaskId);
            if (result == null)
            {
                return task;
            }

            result.UpdatedAt = DateTime.Now.ToUniversalTime();
            _context.Tasks.Update(result);
            _context.TaskDefinitions.Add(task);
            _context.SaveChanges();
            return task;
        }

    }
}