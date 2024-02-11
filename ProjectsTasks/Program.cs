using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ProjectsTasks.Application.Project;
using ProjectsTasks.Application.Role;
using ProjectsTasks.Application.Services;
using ProjectsTasks.Application.Services.Interfaces;
using ProjectsTasks.Application.Task;
using ProjectsTasks.Application.User;
using ProjectsTasks.Infrastruct.Database.DataAccess;
using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Repository;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.utils;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddDbContext<AppDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["TokenSettings:Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["TokenSettings:TokenSecret"])),
        ValidAudience = builder.Configuration["TokenSettings:Audience"]
    };
});

builder.Services.AddSwaggerGen(options => {
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Acesso protegido utilizando o accessToken obtido em \"api/v1/User/login\""
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});
builder.Services.AddAuthorization();


builder.Services.AddScoped<CreateUserUseCase>();
builder.Services.AddScoped<CreateRoleUserCase>();
builder.Services.AddScoped<GetDefaultsRolesUseCase>();
builder.Services.AddScoped<UpdateUserUseCase>();
builder.Services.AddScoped<CreateProjectUseCase>();
builder.Services.AddScoped<GetUserByEmailUseCase>();
builder.Services.AddScoped<CreateTaskUseCase>();
builder.Services.AddTransient<JWTUtils>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<IProjectRepository, ProjectRepository>();
builder.Services.AddScoped<ITaskRepository, TaskRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ITaskService, TaskService>();


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
