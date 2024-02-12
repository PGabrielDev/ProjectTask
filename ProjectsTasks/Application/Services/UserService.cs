using ProjectsTasks.Application.Role.UseCases;
using ProjectsTasks.Application.Services.Interfaces;
using ProjectsTasks.Application.User.DTOs;
using ProjectsTasks.Application.User.UseCases;
using ProjectsTasks.mappers;
using ProjectsTasks.utils;

namespace ProjectsTasks.Application.Services
{
    public class UserService : IUserService
    {
        private readonly CreateUserUseCase CreateUserUseCase;
        private readonly GetDefaultsRolesUseCase GetDefaultsRolesUseCase;
        private readonly UpdateUserUseCase UpdateUserUseCase;
        private readonly GetUserByEmailUseCase GetUserByEmailUseCase;
        private readonly JWTUtils JWTUtils;
        public UserService(CreateUserUseCase createUserUseCase, GetDefaultsRolesUseCase getDefaultsRolesUseCase, UpdateUserUseCase updateUserUseCase, GetUserByEmailUseCase getUserByEmailUseCase, JWTUtils jWTUtils)
        {
            CreateUserUseCase = createUserUseCase;
            GetDefaultsRolesUseCase = getDefaultsRolesUseCase;
            UpdateUserUseCase = updateUserUseCase;
            GetUserByEmailUseCase = getUserByEmailUseCase;
            JWTUtils = jWTUtils;
        }

        public CreateUserOutput CreateUser(CreateUserInput input)
        { 
           
           var hashPw = PasswordUtils.HashPw(input.Password);
           var newUser = User.DTOs.CreateUser.With(
               input.Name,
               input.Email,
               hashPw,
               null
           );
           var output = CreateUserUseCase.Execute(newUser); 
           output = UpdateUserUseCase.Execute(
                UpdateUser.With(output.Id,output.Name, output.Email, newUser.Password)
               );
            
           return output;
        }

        public LoginOutPut Login(LoginInput input)
        {
            var userLogin = GetUserByEmailUseCase.Execute(input.email);
            if (userLogin == null)
            {
                return null;
            }
            if (!PasswordUtils.VerifyPw(input.password, userLogin.password))
            {
                return null;
            }
            var token = JWTUtils.GenerateToken(Mappers.FromUserLoign(userLogin)); 
            var response = LoginOutPut.With(userLogin.email, token);
            return response;
        }
    }
}
