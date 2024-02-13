using Moq;
using ProjectsTasks.Application.Role.DTOs;
using ProjectsTasks.Application.Role.UseCases;
using ProjectsTasks.Application.Task.UseCases;
using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTasks.Test.Application.Role.UseCases
{
    public class CreateRoleUseCaseTest
    {

        public CreateRoleUserCase useCase;
        public Mock<IRoleRepository> roleRepository;

        public CreateRoleUseCaseTest()
        {
            roleRepository = new Mock<IRoleRepository>();

            roleRepository.Setup(r => r.Save(It.IsAny<ProjectsTasks.Infrastruct.Database.entities.Role>())).Returns(new Infrastruct.Database.entities.Role { });   

            useCase = new CreateRoleUserCase(roleRepository.Object);
        }

        [Fact]
        public void GivenAValidParameterWhenCallExecuteThensaveMethodMustbeCalled()
        {
            var listRole = new List<CreateRoleInput>
            {
                CreateRoleInput.With("USER"),
                CreateRoleInput.With("ADMIN")
            };

            foreach (var item in listRole)
            {
                useCase.Execute(item);
            }
            roleRepository.Verify(r => r.Save(It.IsAny<ProjectsTasks.Infrastruct.Database.entities.Role>()), Times.Exactly(2));
        }
    }
}
