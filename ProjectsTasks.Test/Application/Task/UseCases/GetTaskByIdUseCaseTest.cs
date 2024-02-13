using Moq;
using ProjectsTasks.Application.Project.UseCases;
using ProjectsTasks.Application.Task.DTOs;
using ProjectsTasks.Application.Task.UseCases;
using ProjectsTasks.Infrastruct.Database.entities;
using ProjectsTasks.Infrastruct.Database.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTasks.Test.Application.Task.UseCases
{
    public class GetTaskByIdUseCaseTest
    {
        public GetTaskByIdUseCase useCase;
        public Mock<ITaskRepository> taskRepository;

        public GetTaskByIdUseCaseTest()
        {
            taskRepository = new Mock<ITaskRepository>();
            taskRepository.Setup(t => t.GetById(It.IsAny<int>())).Returns(new Infrastruct.Database.entities.Task {Id =1,CreatedAt=DateTime.Now,Priority=Priority.LOW,ProjectId=1,TaskDefinitions = [], UpdatedAt=DateTime.Now });
            useCase = new GetTaskByIdUseCase(this.taskRepository.Object);
            
        }

        [Fact]
        public void GivenAValidParameterWhenCallExecuteThenGeByIdMethodReturnsTaskHistoric()
        {
            var input = 1;
            var result = useCase.Execute(input);
            Assert.NotNull(result);
            Assert.Equal(result.Id, input);
            taskRepository.Verify(x => x.GetById(input), Times.Exactly(1));

        }
    }
}
