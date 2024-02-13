using ProjectsTasks.Application.Project.DTOs;
using ProjectsTasks.Application.Role.DTOs;
using ProjectsTasks.Application.Task.DTOs;
using ProjectsTasks.Application.User.DTOs;
using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.utils;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace ProjectsTasks.mappers
{
    public class Mappers
    {
        public static Dictionary<Status, string> STATUS = new Dictionary<Status, string>
        {
            { Status.BACKLOG, "BACKLOG" },
            { Status.INPROGRESS, "EM ANDAMENTO" },
            { Status.DONE, "FINALIZADO" }
        };

        public static Dictionary<Priority, string> PRIORITY = new Dictionary<Priority, string>
        {
            { Priority.LOW, "BAIXA" },
            { Priority.MEDIUM, "MEDIA"},
            { Priority.HIGH, "ALTA" }
        };


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
                        ChangeDescription = $"Criação de task; criada por: {taskInput.email} em {DateTime.Now}",
                        Comments = [],
                        createdAt = DateTime.Now.ToUniversalTime(),
                        Name = taskInput.name,
                        Stats = Status.BACKLOG,
                        Description = taskInput.description
                    }
                },
            };
        }

        public static TaskDetailOutput FromTaskDetails(Infrastruct.Database.entities.Task task)
        {
            var lastTask = task.TaskDefinitions.LastOrDefault();
            return TaskDetailOutput.With(
                task.Id,
                lastTask.Name,
                lastTask.Description,
                task.ProjectId,
                task.CreatedAt,
                task.UpdatedAt,
                STATUS[lastTask.Stats],
                PRIORITY[task.Priority],
                (lastTask.Assined != null) ? lastTask.Assined.Email : "",
                 task.TaskDefinitions.Select(tf =>
                 {
                     string alter;
                     string by;
                     var alterby = tf.ChangeDescription.Split(";");
                     alter = alterby[0];
                     by = alterby[1];
                     return HistoricOutput.With(alter, by);
                 }).ToList()

                );
        }

        public static TaskApp FromTaskComplete(Infrastruct.Database.entities.Task task)
        {
            return TaskApp.With(
                task.Id,
                (int)task.Priority,
                task.CreatedAt,
                task.UpdatedAt,
                task.TaskDefinitions.Select(tf => TaskDefinitionApp.With(
                    tf.Id,
                    tf.Name,
                    tf.Description,
                    tf.TaskId,
                    (int)tf.Stats,
                    tf.createdAt,
                    tf.Comments.Select(c => CommentsApp.With(
                        c.Id,
                        c.Text,
                        c.Userid, 
                        c.TaskDefinitionId,
                        c.CreatedAt)).ToList(),
                    tf.ChangeDescription

                    )).ToList(),
                task.TaskDefinitions.Select(tf =>
                {
                    string alter;
                    string by;
                    var alterby = tf.ChangeDescription.Split(";");
                    alter = alterby[0];
                    by = alterby[1];
                    return HistoricOutput.With(alter, by);
                }).ToList());
        }

        public static Comment FromAddComment(AddComment comment)
        {
            return new Comment
            {
                CreatedAt = DateTime.Now.ToUniversalTime(),
                Text = comment.comment,
                Userid = comment.userId
            };
        }

        public static string CreateChangeDescription(string email,string alter, string of, string forr)
        {
            return $"{alter} de {of} para {forr};Alterado por: {email} em: {DateTime.Now}";
        }

        public static ProjectOutput FromProject(Project project)
        {
            return new ProjectOutput(
                project.Id,
                project.Name,
                project.Description,
                project.AuthorId,
                project.CreatedAt,
                project.Tasks.Select(t =>
                {
                  var lastTask  = t.TaskDefinitions.LastOrDefault();
                  return SimpleTask.With(lastTask.Id, lastTask.Name, lastTask.Description, t.CreatedAt, t.UpdatedAt, STATUS[lastTask.Stats], PRIORITY[t.Priority] ,(lastTask.Assined != null) ? lastTask.Assined.Email : "");
                }).ToList()
                );
                
        }

    }
}
