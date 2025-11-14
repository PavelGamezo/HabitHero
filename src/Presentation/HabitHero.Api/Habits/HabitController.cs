using HabitHero.Api.Common.Attributes;
using HabitHero.Api.Common.Errors;
using HabitHero.Api.Habits.DTOs;
using HabitHero.Application.Habits.Commands.CompleteHabit;
using HabitHero.Application.Habits.Commands.CreateHabit;
using HabitHero.Application.Habits.Commands.DeleteHabit;
using HabitHero.Application.Habits.Queries.GetUserHabits;
using HabitHero.Domain.Users.Enums;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HabitHero.Api.Habits
{
    [Route("api/habits")]
    public class HabitController : ApiController
    {
        private readonly ISender _sender;

        public HabitController(ISender sender)
        {
            _sender = sender;
        }

        [HasPermission(PermissionsEnum.CreateHabit)]
        [HttpPost]
        public async Task<IActionResult> CreateHabit(
            [FromBody] CreateHabitRequest request)
        {
            Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId);

            if (userId == Guid.Empty)
            {
                return Unauthorized();
            }

            var result = await _sender.Send(new CreateHabitCommand(
                request.Title,
                request.Description,
                request.Frequency,
                userId));

            return result.Match(
                success => Ok(success),
                errors => Problem(errors));
        }

        [HasPermission(PermissionsEnum.ViewHabit)]
        [HttpGet]
        public async Task<IActionResult> GetUserHabits()
        {
            Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId);

            if (userId == Guid.Empty)
            {
                return Unauthorized();
            }

            var result = await _sender.Send(new GetUserHabitsQuery(userId));

            return result.Match(
                habits => Ok(habits),
                errors => Problem(errors));
        }

        [HasPermission(PermissionsEnum.CompleteHabit)]
        [HttpPatch]
        [Route("{id}/complete")]
        public async Task<IActionResult> CompleteHabit(
            [FromRoute] Guid id)
        {
            Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId);

            if (userId == Guid.Empty)
            {
                return Unauthorized();
            }

            var result = await _sender.Send(new CompleteHabitCommand(id, userId));

            return result.Match(
                success => Ok(),
                errors => Problem(errors));
        }

        [HasPermission(PermissionsEnum.DeleteHabit)]
        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<IActionResult> DeleteHabit(
            [FromRoute] Guid id)
        {
            Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId);

            if (userId == Guid.Empty)
            {
                return Unauthorized();
            }

            var result = await _sender.Send(new DeleteHabitCommand(id, userId));

            return result.Match(
                success => Ok(),
                errors => Problem(errors));
        }
    }
}
