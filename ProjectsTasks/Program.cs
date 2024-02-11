using Microsoft.EntityFrameworkCore;
using ProjectsTasks.Application.Role;
using ProjectsTasks.Application.Services;
using ProjectsTasks.Application.Services.Interfaces;
using ProjectsTasks.Application.User;
using ProjectsTasks.Infrastruct.Database.DataAccess;
using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Repository;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddDbContext<AppDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<CreateUserUseCase>();
builder.Services.AddScoped<CreateRoleUserCase>();
builder.Services.AddScoped<GetDefaultsRolesUseCase>();
builder.Services.AddScoped<UpdateUserUseCase>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IUserService, UserService>();

var app = builder.Build();
var context = new AppDbContext(
    new DbContextOptionsBuilder<AppDbContext>()
    .UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")).Options
    );
context.Database.Migrate();

var roles = context.Roles.ToList();
if (roles.Count == 0)
{
    var roless = new List<Role>()
    {
        new Role{Name = "ADMIN" },
        new Role{Name = "USER" },
    };
    context.Roles.AddRange(roless);
    context.SaveChanges();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
