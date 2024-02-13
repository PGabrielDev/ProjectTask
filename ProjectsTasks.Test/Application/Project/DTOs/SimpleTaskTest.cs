using ProjectsTasks.Application.Project.DTOs;
using ProjectsTasks.Infrastruct.Database.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTasks.Test.Application.Project.DTOs
{
    public class SimpleTaskTest
    {
        [Fact]
        public void GivenAValidParametersWhenCallWithThenSuccess()
        {
            const int id = 1;
            const string nameTask = "TaskName";
            const string desctiprion = "description";
            DateTime createAt = DateTime.Now;
            DateTime updateAt = DateTime.Now;
            const string status = "concluido";
            const string priority = "ALTA";
            const string assined = "Matias";

            SimpleTask st = SimpleTask.With(id, nameTask, desctiprion, createAt, updateAt, status, priority, assined);

            Assert.NotNull(st);
            Assert.IsType<SimpleTask>(st);
        }
    }
}

