using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ProjectsTasks.Application.User;
using ProjectsTasks.Infrastruct.Database.DataAccess;
using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Infrastruct.Database.Repository
{
    public class UserRepository : IUserRepository 
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Delete(int id, User entity)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> GetAll()
        {
            return _context.Users.Include(us => us.Roles).ToArray();
        }

        public User? GetByEmail(string email)
        {
            return _context.Users
                .Include(us => us.Roles)
                .ThenInclude(r => r.Role)
                .First(us => us.Email == email);
        }

        public User? GetById(int id)
        {
            var t =  _context.Users.Include(us => us.Roles).First(us => us.Id == id);
            return t;
        }

        public User Save(User value)
        {
             _context.Users.Add(value);
             _context.SaveChanges();
            return value;
        }

        public User Update(User entity)
        {
            var user = _context.Users.FirstOrDefault(us => us.Id == entity.Id);
            if (user == null)
            {
                return entity;
            }
            var roles = _context.Roles.Where(r => !r.Name.Equals("ADMIN")).ToList();
            user.Name = entity.Name;
            user.Email = entity.Email;
            user.Password = entity.Password;
            user.Roles = Mappers.FromRoles(entity.Id,roles);
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }


    }
}
