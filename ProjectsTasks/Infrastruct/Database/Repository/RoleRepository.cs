using ProjectsTasks.Infrastruct.Database.DataAccess;
using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;

namespace ProjectsTasks.Infrastruct.Database.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AppDbContext _context;

        public RoleRepository(AppDbContext context)
        {
            _context = context;
        }

        public ICollection<Role> GetAll()
        {
            var roles = _context.Roles.ToArray();
            return roles;
        }

        public ICollection<Role> GetUsersDefaultRole()
        {
            var roles = _context.Roles.Where(r => !r.Name.Equals("ADMIN")).ToArray();
            return roles;
        }

        public Role Save(Role value)
        {
            _context.Roles.Add(value);
            _context.SaveChanges();
            return value;

        }
    }
}
