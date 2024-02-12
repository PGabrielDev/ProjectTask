using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsTasks.Infrastruct.Database.DataAccess;
using ProjectsTasks.Infrastruct.Database.entities;

namespace ProjectsTasks.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class TesteController: ControllerBase
    {
        private readonly AppDbContext _context;

        public TesteController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var u = _context.Users.FirstOrDefault();

            //user.RoleAccess = BuildRoles(user, roles);
            //_context.Users.Add(u);
            var roless = new List<Role>() 
            {
                new Role { Name = "ADMIN",},
                new Role {Name = "USER", } 
            };
            _context.Roles.AddRange(roless);
            _context.SaveChanges();
            var rr = _context.Roles.ToArray();
            var novoUser = new User
            {
                Email = "EmailTeste@gmail.com",
                Name = "Test",
                Password = "1231",
            };
            novoUser.Roles = BuildRoles(novoUser, rr);
            _context.Users.Add(novoUser);

            _context.SaveChanges();
            var oz = _context.Users.Include(u => u.Roles).ToList();
            var roles = _context.Roles.ToList();
            
            u.Roles = BuildRoles(u, roles);
            
            _context.Users.Update(u);
            _context.SaveChanges();
            var g= _context.Users.Include(u => u.Roles).First();
            

            var p = new Project
            {
                AuthorId = 1,
                Author = u,
                CreatedAt = DateTime.Now.ToUniversalTime(),
                Description = "descricao qualquer",
                Name = "projetinho teste 2",

            };
            
            _context.Projects.Add(p);   
            _context.SaveChanges();
            
            var teste = _context.Projects.Where(p => p.Id == 1).ToArray();
            
            var task = _context.Tasks.Include(t => t.TaskDefinitions).First();
            
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            var taskDefinition = _context.TaskDefinitions.First();
            
            _context.TaskDefinitions.Add(taskDefinition);
            await _context.SaveChangesAsync();

            var taskDefinition2 = new TaskDefinition
            {
                Name = "Gabriel task",
                Assined = u,
                ChangeDescription = "Comment: sdasdasda",
                createdAt = DateTime.Now.ToUniversalTime(),
                Stats = Status.BACKLOG,
                TaskId = task.Id,
                Description = "Descrição bem legal",
                Comments = new List<Comment>() {
                    new Comment
                    {
                        TaskDefinitionId = taskDefinition.Id,
                        Text = "Falei com o Po é sera necessario revisar nates de subir",
                        User = u,
                        Userid = u.Id
                    }
                }
                
            };

            task.TaskDefinitions.Add(taskDefinition2);
            _context.Tasks.Update(task);
            await _context.SaveChangesAsync();

            var tt =  _context.Tasks.Include(t => t.TaskDefinitions).First();






            return Ok();
        }


        private ICollection<UserRole> BuildRoles(User user, ICollection<Role> roles)
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
                    
                        }
                    );
                }
            }
            return result;
        }


    }
}
