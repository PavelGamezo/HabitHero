using ErrorOr;
using HabitHero.Application.Common.CQRS.Queries;
using HabitHero.Application.Common.DTOs;
using HabitHero.Application.Common.DTOs.Configurations;
using HabitHero.Application.Common.Errors;
using HabitHero.Application.Common.Persistence;
using HabitHero.Domain.Users;

namespace HabitHero.Application.Habits.Queries.GetUserHabits
{
    public sealed class GetUserHabitsQueryHandler : IQueryHandler<GetUserHabitsQuery, ErrorOr<List<HabitDto>>>
    {
        private readonly IUserRepository _userRepository;

        public GetUserHabitsQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<List<HabitDto>>> Handle(GetUserHabitsQuery request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;

            var user = await _userRepository.GetUserWithHabitsByIdAsync(userId, cancellationToken);

            if (user is null)
            {
                return UserApplicationErrors.NotFoundUserError;
            }

            var habits = user.Habits
                .Select(habit => habit.Map<HabitDto>())
                .ToList();

            return habits;
        }
    }
}
