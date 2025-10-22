using HabitHero.Application.Users.Commands.RegisterUser;
using HabitHero.Application.Users.Queries.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HabitHero.Api.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterUserRequest request)
        {
            var result = await _sender.Send(new RegisterUserCommand(
                request.Username,
                request.Email,
                request.Password));

            if (result.IsError)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login([FromQuery]LoginUserRequest request)
        {
            var result = await _sender.Send(new LoginUserQuery(
                request.Email,
                request.Password));

            if (result.IsError)
            {
                return BadRequest(result.Errors);
            }

            return Ok(result);
        }
    }
}
