using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using ProjectsTasks.mappers;

namespace ProjectsTasks.Application.User
{
    public class GetUserByEmailUseCase : UseCase<string, UserLogin>
    {
        private IUserRepository userRepository;

        public GetUserByEmailUseCase(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public UserLogin Execute(string input)
        {
            var user = userRepository.GetByEmail(input);
            if (user == null)
            {
                return null;
            }
            return Mappers.FromUserGenerateLogin(user);
        }
    }
}
