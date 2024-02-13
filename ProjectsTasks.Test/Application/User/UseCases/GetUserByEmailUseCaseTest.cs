using Moq;
using ProjectsTasks.Application.User.DTOs;
using ProjectsTasks.Application.User.UseCases;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTasks.Test.Application.User.UseCases
{
    public  class GetUserByEmailUseCaseTest
    {
        public GetUserByEmailUseCase useCase;
        public Mock<IUserRepository> userRepository;

        public GetUserByEmailUseCaseTest()
        {
            userRepository = new Mock<IUserRepository>();
            userRepository.Setup(u => u.GetByEmail("matias@gmail.com")).Returns(new ProjectsTasks.Infrastruct.Database.entities.User { Email = "matias@gmail.com", Id = 1, Name = "matias",Roles = [] });
            useCase = new GetUserByEmailUseCase(userRepository.Object);
        }

        [Fact]
        public void GivenAValidParameterWhenCallExecuteThenReturnsUserLogin()
        {
            var email = "matias@gmail.com";
            var result = useCase.Execute(email);
            Assert.Equal(email, result.email);
            Assert.IsType<UserLogin>(result);
            userRepository.Verify(u => u.GetByEmail(email), Times.Exactly(1));
        }
        [Fact]
        public void GivenAEmailNotFoudWhenCallExecuteThenReturnsNull()
        {
            var email = "gabriel@gmail.com";
            var result = useCase.Execute(email);
            Assert.Null(result);
            userRepository.Verify(u => u.GetByEmail(email), Times.Exactly(1));
        }
    }
}
