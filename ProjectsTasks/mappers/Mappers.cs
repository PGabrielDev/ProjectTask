using ProjectsTasks.Application.Project;
using ProjectsTasks.Application.Role;
using ProjectsTasks.Application.Task;
using ProjectsTasks.Application.User;
using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.utils;
using System.Data;
using System.Drawing;

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

        public static UserLogin FromUserGenerateLogin(User user)
        {
            return UserLogin.With(user.Id,user.Email,user.Password ,user.Roles.Select(r => RoleOutput.With(r.Id,r.Role.Name)).ToList());
        }

       
        public static EmailRole FromUserLoign(UserLogin login)
        {
            return EmailRole.With(login.email, login.roles.Select(r => r.Name).ToList());
        }

        public static Project FromProjectCreate(CreateProject project)
        {
            return new Project
            {
                Name = project.ProjectName,
                Description = project.Description,
                AuthorId = project.UserId,
                CreatedAt = DateTime.Now.ToUniversalTime(),
            };

        }

        public static Infrastruct.Database.entities.Task FromTaskCreate(CreateTask taskInput)
        {
            return new Infrastruct.Database.entities.Task
            {
                Priority = (taskInput.priority < 0 || taskInput.priority > 2) ? Priority.LOW : (Priority)taskInput.priority,
                CreatedAt = DateTime.Now.ToUniversalTime(),
                ProjectId = taskInput.projectId,
                TaskDefinitions = new List<TaskDefinition>() {
                    new TaskDefinition
                    {
                        ChangeDescription = "task inciada",
                        Comments = [],
                        createdAt = DateTime.Now.ToUniversalTime(),
                        Name = taskInput.name,
                        Stats = Status.BACKLOG,
                        Description = taskInput.description
                    }
                },
            };
        }
    }
}
