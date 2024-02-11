using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectsTasks.Application.Project;
using ProjectsTasks.Application.Services.Interfaces;
using ProjectsTasks.Application.Task;
using System.Runtime.ConstrainedExecution;

namespace ProjectsTasks.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProjectController : ControllerBase
    {

        private readonly IProjectService _projectService;
        private readonly ITaskService _taskService;
        public ProjectController(IProjectService projectService, ITaskService taskService)
        {
            _projectService = projectService;
            _taskService = taskService;
        }

        [HttpPost]
        [Authorize(Roles = "USER")]
        public IActionResult CreateProject([FromBody] CreateProjectInput input)
        {
            var email = User?.Identity?.Name;
            if (email == null)
            {
                return BadRequest();

            }
            if (email != input.email) 
            { 
                return BadRequest();

            }

            _projectService.CreateProject(input);

            return Created();
        }

        [HttpPost("{projectId}/task")]
        [Authorize(Roles = "USER")]
        public IActionResult AddTaskInProject([FromBody] CreateTaskInput input, [FromRoute] int projectId)
        {
            var email = User?.Identity?.Name;
            if (email == null)
            {
                return BadRequest();
            }
            var taskInput = CreateTask.With(projectId, input.priority, input.name, input.description);
            _taskService.CreateTask(taskInput);
            return NoContent();
        }
    }
}
