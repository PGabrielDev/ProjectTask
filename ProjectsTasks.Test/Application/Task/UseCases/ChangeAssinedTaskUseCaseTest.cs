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
    public class ChangeAssinedTaskUseCaseTest
    {
        public ChangeAssinedTaskUseCase useCase;
        public Mock<ITaskRepository> taskRepository;

        public ChangeAssinedTaskUseCaseTest()
        {
            taskRepository = new Mock<ITaskRepository>();
            taskRepository.Setup(t => t.Update(It.IsAny<ProjectsTasks.Infrastruct.Database.entities.TaskDefinition>())).Returns(new Infrastruct.Database.entities.TaskDefinition { });
            taskRepository.Setup(t => t.GetById(It.IsAny<int>())).Returns(new Infrastruct.Database.entities.Task
            {
                TaskDefinitions = new List<TaskDefinition>()
            {
                new TaskDefinition
                {
                    Assined = new User {},
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
            useCase = new ChangeAssinedTaskUseCase(this.taskRepository.Object);
            
        }

        [Fact]
        public void GivenAValidParameterAndListTaskNotCompletesWhenCallExecuteThenReturnsSuccess()
        {
            
            var creatTask = ChangeAssinedTask.With(1,1,1,"matias@gmail.com");
            useCase.Execute(creatTask);
            taskRepository.Verify(x => x.Update(It.IsAny<ProjectsTasks.Infrastruct.Database.entities.TaskDefinition>()), Times.Exactly(1));
            taskRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Exactly(1));
        }
    }
}
