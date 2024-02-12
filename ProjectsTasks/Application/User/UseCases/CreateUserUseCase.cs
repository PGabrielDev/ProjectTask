using ProjectsTasks.Application.User.DTOs;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.User.UseCases
{
    public class CreateUserUseCase : UseCase<CreateUser, CreateUserOutput>
    {
        private readonly IUserRepository repository;

        public CreateUserUseCase(IUserRepository repository)
        {
            this.repository = repository;
        }

        public CreateUserOutput Execute(CreateUser input)
        {
            var user = Mappers.FromCreateUserInput(input);
            repository.Save(user);
            return Mappers.FromUser(user);
        }
    }
}
