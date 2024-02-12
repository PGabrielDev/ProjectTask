using ProjectsTasks.Application.User.DTOs;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.User.UseCases
{
    public class UpdateUserUseCase : UseCase<UpdateUser, CreateUserOutput>
    {
        public IUserRepository Repository { get; set; }

        public UpdateUserUseCase(IUserRepository repository)
        {
            Repository = repository;
        }

        public CreateUserOutput Execute(UpdateUser input)
        {
            var user = Mappers.FromUpdateUserInputWithRoles(input);

            Repository.Update(user);
            return Mappers.FromUser(user);
        }
    }
}
