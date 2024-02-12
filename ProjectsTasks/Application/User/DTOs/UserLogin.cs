using ProjectsTasks.Application.Role.DTOs;
using ProjectsTasks.Infrastruct.Database.entities;
using System.ComponentModel.DataAnnotations;

namespace ProjectsTasks.Application.User.DTOs
{
    public record UserLogin(int id, string email, string password, ICollection<RoleOutput> roles)
    {
        public static UserLogin With(int id, string email, string password, ICollection<RoleOutput> roles)
        {
            return new UserLogin(id, email, password, roles);
        }
    }
}

