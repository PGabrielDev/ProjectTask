using ProjectsTasks.Application.Project.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTasks.Test.Application.Project.DTOs
{
    

    public class CreateProjectInputTest
    {
        

        [Fact]
        public void GivenAValidParametersWhenCallWithThenSuccess()
        {
            var projectDescription = "description teste";
            var projectName = "project name";

            var project = CreateProjectInput.With(projectName, projectDescription);

            Assert.NotNull(project);
            Assert.Equal(projectName, project.ProjectName);
            Assert.Equal(projectDescription, project.Description);
            Assert.IsType<CreateProjectInput>(project);
        }
    }
    
}
