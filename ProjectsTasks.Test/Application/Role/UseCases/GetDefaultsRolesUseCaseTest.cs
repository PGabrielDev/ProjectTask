using Moq;
using ProjectsTasks.Application.Role.UseCases;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTasks.Test.Application.Role.UseCases
{
    public class GetDefaultsRolesUseCaseTest
    {

        public GetDefaultsRolesUseCase useCase;
        public Mock<IRoleRepository> roleRepository;

        public GetDefaultsRolesUseCaseTest()
        {
            roleRepository = new Mock<IRoleRepository>();

            roleRepository.Setup(r => r.GetUsersDefaultRole()).Returns(new List<Infrastruct.Database.entities.Role> { });

            useCase = new GetDefaultsRolesUseCase(roleRepository.Object);
        }

        [Fact]
        public void GivenAValidParameterWhenCallExecuteThenGetUsersDefaultRoleMethodMustbeCalled()
        {
            useCase.Execute();
            roleRepository.Verify(r => r.GetUsersDefaultRole(), Times.Exactly(1));

        }
    }
}
