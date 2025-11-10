using ErrorOr;
using HabitHero.Application.Common.CQRS.Queries;
using HabitHero.Application.Common.DTOs;

namespace HabitHero.Application.Users.Queries.GetProfile
{
    public record GetUserProfileQuery(Guid UserId) : IQuery<ErrorOr<GetUserProfileDto>>;
}
