using ProjectsTasks.Application.Project.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectsTasks.Test.Application.Project.DTOs
{
    public class ReportOutputTest
    {
        [Fact]
        public void GivenAValidParametersWhenCallWithThenSuccess()
        {
            ReportOutPut report = ReportOutPut.With("PAULO MATIAS", 1.36);
            Assert.NotNull(report);
            Assert.IsType<ReportOutPut>(report);
        }
    }
}
