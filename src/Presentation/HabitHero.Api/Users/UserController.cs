using HabitHero.Api.Common.Attributes;
using HabitHero.Api.Common.Errors;
using HabitHero.Api.Users.DTOs;
using HabitHero.Application.Users.Commands.RegisterUser;
using HabitHero.Application.Users.Queries.GetProfile;
using HabitHero.Application.Users.Queries.LoginUser;
using HabitHero.Domain.Users.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HabitHero.Api.Users
{
    [Route("api/auth")]
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

        [HasPermission(PermissionsEnum.ViewProfile)]
        [HttpGet]
        [Route("me")]
        public async Task<IActionResult> GetProfile()
        {
            Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var userId);
            
            if (userId == Guid.Empty)
            {
                return Unauthorized();
            }

            var result = await _sender.Send(new GetUserProfileQuery(userId));

            return result.Match(
                success => Ok(result.Value),
                errors => Problem(errors));
        }
    }
}
