using ErrorOr;
using HabitHero.Application.Common.CQRS.Queries;
using HabitHero.Application.Common.DTOs;
using HabitHero.Application.Common.DTOs.Configurations;
using HabitHero.Application.Common.Errors;
using HabitHero.Application.Common.Persistence;
using HabitHero.Application.Common.Services;
using HabitHero.Application.Users.Queries.GetProfile;

namespace HabitHero.Application.Users.Queries.GetUserProfile
{
    public class GetUserProfileQueryHandler(
        IUserRepository userRepository)
        : IQueryHandler<GetUserProfileQuery, ErrorOr<GetUserProfileDto>>
    {
        public async Task<ErrorOr<GetUserProfileDto>> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;

            var user = await userRepository.GetUserByIdAsync(userId, cancellationToken);
            if (user is null)
            {
                return UserApplicationErrors.NotFoundUserError;
            }

            var userDto = user.Map<GetUserProfileDto>();

            return userDto;
        }
    }
}
