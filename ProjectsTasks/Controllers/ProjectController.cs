using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectsTasks.Application.Project.DTOs;
using ProjectsTasks.Application.Services.Interfaces;
using ProjectsTasks.Application.Task.DTOs;
using ProjectsTasks.Infrastruct.Database.Exceptions;
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

            _projectService.CreateProject(input, email);

            return Created();
        }

        [HttpGet("generateReport")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult GenerateReport()
        {
            var output = _taskService.GenerateReport();
            return Ok(output);
        }

        [HttpGet]
        public IActionResult GetAllProject()
        {
            var output = _projectService.GetProjects();
            return Ok(output);
        }

        [HttpGet("{userId}")]
        public IActionResult GetAllProject([FromRoute] int userId)
        {
            var output = _projectService.GetProjectsByUserID(userId);
            return Ok(output);
        }


        [HttpDelete("{projectId}")]
        [Authorize(Roles = "USER")]
        public IActionResult DeleteProject([FromRoute] int projectId)
        {
            try
            {
                _projectService.DeleteProject(projectId);
            } catch (IncompleteProjectException ex)
            {
                return BadRequest(new {error = ex.Message});
            }
            return NoContent();

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
            try
            {
                var taskInput = CreateTask.With(projectId, input.priority, input.name, input.description, email);
                _taskService.CreateTask(taskInput);
                return NoContent();
            }
            catch (LimitTaskException ex) {
                return BadRequest(new {error = ex.Message});
            }
            
        }

        [HttpPost("{projectId}/task/{taskId}/addComment")]
        [Authorize(Roles = "USER")]
        public IActionResult AddCommentProjectTask([FromRoute] int projectId, [FromRoute] int taskId, [FromBody] AddCommentInput input)
        {
            var email = User?.Identity?.Name;
            if (email == null)
            {
                return BadRequest();
            }
            _taskService.AddComment(input, projectId, taskId, email);
            return NoContent();
        }

        [HttpPost("task/{taskId}/changeStatus")]
        [Authorize(Roles = "USER")]
        public IActionResult ChangeStatus([FromRoute] int taskId ,[FromBody] ChangeStatusInput input) 
        {
            var email = User?.Identity?.Name;
            if (email == null)
            {
                return BadRequest();
            }
            _taskService.ChangeStatusTask(taskId, input,email);
            return NoContent();
        }

        [HttpPost("task/{taskId}/changeDescription")]
        [Authorize(Roles = "USER")]

        public IActionResult ChangeDescription([FromRoute] int taskId, [FromBody] ChangeDescriptionInput input)
        {
            var email = User?.Identity?.Name;
            if (email == null)
            {
                return BadRequest();
            }
            _taskService.ChangeDescription(taskId, input, email);
            return NoContent();
        }
        [HttpPost("task/{taskId}/addAssined")]
        [Authorize(Roles = "USER")]
        public IActionResult ChangeAssined([FromRoute] int taskId, [FromBody] ChangeAssinedTaskInput input)
        {
            var email = User?.Identity?.Name;
            if (email == null)
            {
                return BadRequest();
            }
            _taskService.ChangeAssinedTask(taskId, input, email);
            return NoContent();
        }

        [HttpPost("task/{taskId}/changeName")]
        [Authorize(Roles = "USER")]

        public IActionResult ChangeName([FromRoute] int taskId, [FromBody] ChangeNameInput input)
        {
            var email = User?.Identity?.Name;
            if (email == null)
            {
                return BadRequest();
            }
            _taskService.ChangeNameTask(taskId, input,email);
            return NoContent();
        }

        [HttpDelete("task/{taskId}")]
        [Authorize(Roles = "USER")]
        public IActionResult Delete([FromRoute] int taskId)
        {
            _taskService.DeleteTask(taskId);
            return NoContent();
        }

        [HttpGet("/task/{taskId}/historicComplete")]
        public IActionResult GetHistoricComplete([FromRoute] int taskId)
        {
            var result = _taskService.GetTaskByIdCompleteHistoric(taskId);
            return Ok(result);
        }

        [HttpGet("/task/{taskId}")]
        public IActionResult GetTaskById([FromRoute] int taskId)
        {
            var result = _taskService.GetTaskByIdDetails(taskId);
            return Ok(result);
        }
    }
}
