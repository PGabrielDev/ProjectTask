using ProjectsTasks.Application.Role;
using ProjectsTasks.Application.Services.Interfaces;
using ProjectsTasks.Application.User;
using ProjectsTasks.mappers;
using ProjectsTasks.utils;

namespace ProjectsTasks.Application.Services
{
    public class UserService : IUserService
    {
        private readonly CreateUserUseCase CreateUserUseCase;
        private readonly GetDefaultsRolesUseCase GetDefaultsRolesUseCase;
        private readonly UpdateUserUseCase UpdateUserUseCase;
        public UserService(CreateUserUseCase createUserUseCase, GetDefaultsRolesUseCase getDefaultsRolesUseCase, UpdateUserUseCase updateUserUseCase)
        {
            CreateUserUseCase = createUserUseCase;
            GetDefaultsRolesUseCase = getDefaultsRolesUseCase;
            UpdateUserUseCase = updateUserUseCase;
        }

        public CreateUserOutput CreateUser(CreateUserInput input)
        { 
           
           var hashPw = PasswordUtils.HashPw(input.Password);
           var newUser = User.CreateUser.With(
               input.Name,
               input.Email,
               hashPw,
               null
           );
           var output = CreateUserUseCase.Execute(newUser); 
           output = UpdateUserUseCase.Execute(
                User.UpdateUser.With(output.Id,output.Name, output.Email, newUser.Password)
               );
            
           return output;
        }
    }
}
