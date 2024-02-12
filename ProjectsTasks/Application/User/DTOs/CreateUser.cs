using ProjectsTasks.Application.Role.DTOs;

namespace ProjectsTasks.Application.User.DTOs
{
    public record CreateUser(string Name, string Email, string Password, ICollection<RoleInput> Roles)
    {
        public static CreateUser With(string Name, string Email, string Password, ICollection<RoleInput> Roles)
        {
            return new CreateUser(Name, Email, Password, Roles);
        }
    }
}
