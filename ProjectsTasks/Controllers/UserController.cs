using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectsTasks.Application.Services.Interfaces;
using ProjectsTasks.Application.User;

namespace ProjectsTasks.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUseR([FromBody] CreateUserInput input)
        {
            var outPut = _userService.CreateUser(input);
            return Ok(outPut);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginInput input)
        {
            var output = _userService.Login(input);
            if (output == null)
            {
                return BadRequest("Login fail");
            }
            return Ok(output);
        }

    }
}
