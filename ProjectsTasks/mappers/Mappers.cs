using ProjectsTasks.Application.Role;
using ProjectsTasks.Application.User;
using ProjectsTasks.Infrastruct.Database.entities;
using System.Data;

namespace ProjectsTasks.mappers
{
    public class Mappers
    {
        public static User FromCreateUserInput(CreateUser input)
        {
            var user = new User
            {
                Email = input.Email,
                Name = input.Name,
                Password = input.Password
            };
            
            return user;
        }
        public static User FromUpdateUserInputWithRoles(UpdateUser input)
        {
            var user = new User
            {
                Id = input.Id,
                Email = input.Email,
                Name = input.Name,
                Password = input.Password
            };
            return user;
        }
        
        public static CreateUserOutput FromUser(User user)
        {
            return CreateUserOutput.With(user.Id,user.Name, user.Email);
        }

        public static Role FromRoleInput(RoleInput input)
        {
            return new Role
            {
                Name = input.Name,
                Id = input.Id,
            };
        }
        

        public static Role FromRoleInput(CreateRoleInput input)
        {
            return new Role
            {
                Name = input.Name
            };
        }

        public static RoleOutput FromRole(Role role)
        {
            return RoleOutput.With(role.Id, role.Name);
        }


        public static ICollection<UserRole> FromRoles(int userId, ICollection<Role> roles)
        {
            ICollection<UserRole> result = new HashSet<UserRole>();

            foreach (var item in roles)
            {
                if (item.Name != "ADMIN")
                {
                    result.Add(
                        new UserRole
                        {
                            Role = item,
                            RoleId = item.Id,
                            userId = userId
                        }
                    );
                }
            }
            return result;
        }
    }
}
