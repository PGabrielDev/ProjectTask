﻿using Moq;
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
    public class ChangeStatusUseCaseTest
    {
        public ChangeStatusTaskUseCase useCase;
        public Mock<ITaskRepository> taskRepository;

        public ChangeStatusUseCaseTest()
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
            useCase = new ChangeStatusTaskUseCase(this.taskRepository.Object);
            
        }

        [Fact]
        public void GivenAValidParameterWhenCallExecuteThenUpdateMethodMusBeCalled()
        {
            var changeStatus = ChangeStatus.With(2, 1, "matias@teste.com");
            useCase.Execute(changeStatus);
            taskRepository.Verify(x => x.Update(It.IsAny<ProjectsTasks.Infrastruct.Database.entities.TaskDefinition>()), Times.Exactly(1));
            taskRepository.Verify(x => x.GetById(It.IsAny<int>()), Times.Exactly(1));

        }
    }
}
