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
    public class ChangeDescriptionUseCaseTest
    {
        public ChangeDescriptionUseCase useCase;
        public Mock<ITaskRepository> taskRepository;

        public ChangeDescriptionUseCaseTest()
        {
            taskRepository = new Mock<ITaskRepository>();
            taskRepository.Setup(t => t.Update(It.IsAny<ProjectsTasks.Infrastruct.Database.entities.TaskDefinition>())).Returns(new Infrastruct.Database.entities.TaskDefinition { });
            taskRepository.Setup(t => t.GetById(It.IsAny<int>())).Returns(new Infrastruct.Database.entities.Task
            {
                TaskDefinitions = new List<TaskDefinition>()
            {
                new TaskDefinition
                {
                    Assined = new Infrastruct.Database.entities.User {},
                    ChangeDescription = "Test",
                    Comments = new List<Comment> {},
                    AssinedId = 1,
                    createdAt = DateTime.Now,
                    Description = "Test",
                    Id = 1,
                    Name = "Test",
                    Stats = Status.DONE,
                    TaskId = 1
                }
            }
            });
            useCase = new ChangeDescriptionUseCase(this.taskRepository.Object);
            
        }

        [Fact]
        public void GivenAValidParameterWhenCallExecuteThenUpdateMethodMusBeCalled()
        {
            var changeDescription = ChangeDescription.With("O parceiro NPT não consegue calcular ofertas é preciso verificar o motivo", 1, "matias@teste.com");
            useCase.Execute(changeDescription);
            taskRepository.Verify(x => x.Update(It.IsAny<ProjectsTasks.Infrastruct.Database.entities.TaskDefinition>()), Times.Exactly(1));
            taskRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Exactly(1));

        }
    }
}
