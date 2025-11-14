using ErrorOr;
using HabitHero.Application.Common.CQRS.Commands;
using HabitHero.Application.Common.Errors;
using HabitHero.Application.Common.Persistence;

namespace HabitHero.Application.Habits.Commands.UpdateHabit
{
    public sealed class UpdateHabitCommandHandler : ICommandHandler<UpdateHabitCommand, ErrorOr<Updated>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IHabitRepository _habitRepository;

        public UpdateHabitCommandHandler(IUserRepository userRepository,
            IHabitRepository habitRepository)
        {
            _userRepository = userRepository;
            _habitRepository = habitRepository;
        }

        public async Task<ErrorOr<Updated>> Handle(UpdateHabitCommand request, CancellationToken cancellationToken)
        {
            var (habitId, title, description, userId) = request;

            var user = await _userRepository.GetUserWithHabitsByIdAsync(habitId, cancellationToken);
            if (user is null)
            {
                return UserApplicationErrors.NotFoundUserError;
            }

            var habit = await _habitRepository.GetHabitByIdAsync(habitId, cancellationToken);
            if (habit is null)
            {
                return HabitApplicationErrors.NotFoundHabitError;
            }

            if (!user.IsUserHasHabit(habitId))
            {
                return HabitApplicationErrors.NotFoundHabitError;
            }

            var result = habit.ChangeInfo(title, description);
            if (result.IsError)
            {
                return result.Errors;
            }

            await _habitRepository.SaveAsync(cancellationToken);

            return Result.Updated;
        }
    }
}
