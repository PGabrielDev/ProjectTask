using Moq;
using ProjectsTasks.Application.Role.UseCases;
using ProjectsTasks.Application.User.DTOs;
using ProjectsTasks.Application.User.UseCases;
using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTasks.Test.Application.User.UseCases
{
    public class UpdateUserUseCaseTest
    {
        public UpdateUserUseCase useCase;
        public Mock<IUserRepository> userRepository;

        public UpdateUserUseCaseTest()
        {
            userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.Update(It.IsAny < ProjectsTasks.Infrastruct.Database.entities.User>())).Returns(new ProjectsTasks.Infrastruct.Database.entities.User {Id=1,Email="gabriel@gmail.com",Name="gabriel" });
            useCase = new UpdateUserUseCase(userRepository.Object);
        }

        [Fact]
        public void GivenAValidUpdateParameterWhenCallExecuteThenReturnsSuccess()
        {
            var user = UpdateUser.With(1,"Gabriel", "gabriel@gmail.com", "123321");
            var result = useCase.Execute(user);
            userRepository.Verify(u => u.Update(It.IsAny<ProjectsTasks.Infrastruct.Database.entities.User>()), Times.Exactly(1));

        }
    }
}
