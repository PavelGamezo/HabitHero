using ErrorOr;
using HabitHero.Application.Common.CQRS.Commands;
using HabitHero.Application.Common.Errors;
using HabitHero.Application.Common.Persistence;

namespace HabitHero.Application.Habits.Commands.CompleteHabit
{
    public sealed class CompleteHabitCommandHandler : ICommandHandler<CompleteHabitCommand, ErrorOr<Success>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHabitRepository _habitRepository;

        public CompleteHabitCommandHandler(IUserRepository userRepository,
            IHabitRepository habitRepository)
        {
            _userRepository = userRepository;
            _habitRepository = habitRepository;
        }

        public async Task<ErrorOr<Success>> Handle(CompleteHabitCommand request, CancellationToken cancellationToken)
        {
            var (habitId, userId) = request;

            var user = await _userRepository.GetUserWithHabitsByIdAsync(userId, cancellationToken);
            if (user is null)
            {
                return UserApplicationErrors.NotFoundUserError;
            }

            if (!user.IsUserHasHabit(habitId))
            {
                return HabitApplicationErrors.NotFoundHabitError;
            }

            var habit = await _habitRepository.GetHabitByIdAsync(habitId, cancellationToken);
            if (habit is null)
            {
                return HabitApplicationErrors.NotFoundHabitError;
            }

            var completeResult = habit.Complete();
            if (completeResult.IsError)
            {
                return completeResult.Errors;
            }

            user.ChangeExperience();

            await _habitRepository.SaveAsync(cancellationToken);

            return Result.Success;
        }
    }
}
