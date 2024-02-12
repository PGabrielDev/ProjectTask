using ProjectsTasks.Application.Role.DTOs;

namespace ProjectsTasks.Application.User.DTOs
{
    public record UserRoleInput(RoleInput Role, int RoleId, int UserId)
    {
        public static UserRoleInput With(RoleInput Role, int RoleId, int UserId)
        {
            return new UserRoleInput(Role, RoleId, UserId);
        }
    }
}
