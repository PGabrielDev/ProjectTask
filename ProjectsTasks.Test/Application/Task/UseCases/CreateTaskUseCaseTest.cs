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
    public class CreateTaskUseCaseTest
    {
        public CreateTaskUseCase useCase;
        public Mock<ITaskRepository> taskRepository;

        public CreateTaskUseCaseTest()
        {
            taskRepository = new Mock<ITaskRepository>();
            taskRepository.Setup(t => t.Save(It.IsAny<ProjectsTasks.Infrastruct.Database.entities.Task>())).Returns(new Infrastruct.Database.entities.Task { });
            useCase = new CreateTaskUseCase(this.taskRepository.Object);
            
        }

        [Fact]
        public void GivenAValidParameterWhenCallExecuteThenUpdateMethodMusBeCalled()
        {
            var creatTask = CreateTask.With(1,2,"Task","descrição", "teste@teste.com");
            useCase.Execute(creatTask);
            taskRepository.Verify(x => x.Save(It.IsAny<ProjectsTasks.Infrastruct.Database.entities.Task>()), Times.Exactly(1));

        }
    }
}
