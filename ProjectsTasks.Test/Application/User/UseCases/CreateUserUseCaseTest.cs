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
    public class CreateUserUseCaseTest
    {
        public CreateUserUseCase useCase;
        public Mock<IUserRepository> userRepository;

        public CreateUserUseCaseTest()
        {
            userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.Save(It.IsAny < ProjectsTasks.Infrastruct.Database.entities.User>())).Returns(new ProjectsTasks.Infrastruct.Database.entities.User { });
            useCase = new CreateUserUseCase(userRepository.Object);
        }

        [Fact]
        public void GivenAValidParameterWhenCallExecuteThenSaveMethodMusBeCalled()
        {
            var user = CreateUser.With("Gabriel", "gabriel@gmail.com", "123321", null);
            useCase.Execute(user);
            userRepository.Verify(u => u.Save(It.IsAny<ProjectsTasks.Infrastruct.Database.entities.User>()), Times.Exactly(1));

        }
    }
}
