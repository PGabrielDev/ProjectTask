using Microsoft.EntityFrameworkCore;
using ProjectsTasks.Infrastruct.Database.entities;

namespace ProjectsTasks.Infrastruct.Database.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<entities.Task> Tasks { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Role> Roles { get; set; }
        public DbSet<TaskDefinition> TaskDefinitions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne()
                .HasForeignKey(t => t.ProjectId);
            
            modelBuilder.Entity<Project>()
            .HasOne(p => p.Author)
            .WithMany()
            .HasForeignKey(p => p.AuthorId);
           
            modelBuilder.Entity<entities.Task>()
                .HasMany(t => t.TaskDefinitions)
                .WithOne()
                .HasForeignKey(t => t.TaskId);

            modelBuilder.Entity<TaskDefinition>()
                .HasMany(td => td.Comments)
                .WithOne()
                .HasForeignKey(c => c.TaskDefinitionId);

            modelBuilder.Entity<TaskDefinition>()
                .HasOne(td => td.Assined)
                .WithMany()
                .HasForeignKey(td => td.AssinedId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.Userid);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithOne()
                .HasForeignKey(r => r.userId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany()
                .HasForeignKey(ur => ur.RoleId);

           
                

            base.OnModelCreating(modelBuilder);
        }

    }

}
 