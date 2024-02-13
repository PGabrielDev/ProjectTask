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
    public class GetTaskSimpleDetailsByIdTest
    {
        public GetTaskSimpleDetailsById useCase;
        public Mock<ITaskRepository> taskRepository;

        public GetTaskSimpleDetailsByIdTest()
        {
            taskRepository = new Mock<ITaskRepository>();
            taskRepository.Setup(t => t.GetById(It.IsAny<int>()))
                .Returns(new Infrastruct.Database.entities.Task {
                    Id = 1, 
                    CreatedAt = DateTime.Now, 
                    Priority = Priority.LOW, 
                    ProjectId = 1, 
                    TaskDefinitions  = new List<TaskDefinition>()
                        {
                            new TaskDefinition
                            {
                                Assined = new Infrastruct.Database.entities.User {},
                                ChangeDescription = "Tarefa inicianda: em 24/10/2025; por matias@gmail.com",
                                Comments = new List<Comment> {},
                                AssinedId = 1,
                                createdAt = DateTime.Now,
                                Description = "Test",
                                Id = 1,
                                Name = "Test",
                                Stats = Status.DONE,
                                TaskId = 1,

                            }
                        }, 
                    UpdatedAt = DateTime.Now 
                });

            useCase = new GetTaskSimpleDetailsById(this.taskRepository.Object);
            
        }

        [Fact]
        public void GivenAValidParameterWhenCallExecuteThenGeByIdMethodReturnsTaskHistoricSimple()
        {
            
            int taskid = 1;
            var result = useCase.Execute(1);
            Assert.NotNull(result);
            Assert.Equal(taskid, result.id);
            taskRepository.Verify(x => x.GetById(taskid), Times.Exactly(1));

        }
    }
}
