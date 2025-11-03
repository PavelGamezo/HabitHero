using HabitHero.Api.Common.Attributes;
using HabitHero.Api.Common.Errors;
using HabitHero.Api.Users.DTOs;
using HabitHero.Application.Users.Commands.RegisterUser;
using HabitHero.Application.Users.Queries.LoginUser;
using HabitHero.Domain.Users.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HabitHero.Api.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
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

            return result.Match(
                success => Ok(success),
                errors => Problem(errors));
        }

        [HttpGet]
        [Route("login")]
        public async Task<IActionResult> Login([FromQuery]LoginUserRequest request)
        {
            var result = await _sender.Send(new LoginUserQuery(
                request.Email,
                request.Password));

            return result.Match(
                success => Ok(success),
                errors => Problem(errors));
        }

        [HasPermission(PermissionsEnum.ResetUserProgress)]
        [HttpGet]
        [Route("Test")]
        public IActionResult GetTest()
        {
            return Ok();
        }
    }
}
