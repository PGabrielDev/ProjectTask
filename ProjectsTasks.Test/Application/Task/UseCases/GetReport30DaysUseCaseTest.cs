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
    public class GetReport30DaysUseCaseTest
    {
        public GetReport30DaysUseCase useCase;
        public Mock<ITaskRepository> taskRepository;

        public GetReport30DaysUseCaseTest()
        {
            taskRepository = new Mock<ITaskRepository>();
            taskRepository.Setup(t => t.GetAllTask30Days())
                .Returns(new List<Infrastruct.Database.entities.Task> 
                    {
                        new Infrastruct.Database.entities.Task {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    Priority = Priority.LOW,
                    ProjectId = 1,
                    TaskDefinitions  = new List<TaskDefinition>()
                        {
                            new TaskDefinition
                            {
                                Assined = new Infrastruct.Database.entities.User {
                                    Id = 1,
                                    Email = "matias@teste.com",
                                    Name = "matias",
                                },
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
                }
                    }
                );
            useCase = new GetReport30DaysUseCase(this.taskRepository.Object);
            
        }

        [Fact]
        public void GivenAValidParameterWhenCallExecuteThenReturnListAvarage()
        {

            var result = useCase.Execute();
            Assert.NotNull( result );  
            Assert.Equal( 1, result.Count );
            var report = result.LastOrDefault();
            Assert.NotNull( report );
            Assert.Equal("matias@teste.com", report.user);
            Assert.Equal((double)1 / 30, report.avarege);
        }
    }
}


