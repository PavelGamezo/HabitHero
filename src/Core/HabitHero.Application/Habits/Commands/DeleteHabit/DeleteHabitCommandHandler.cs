using ErrorOr;
using HabitHero.Application.Common.CQRS.Commands;
using HabitHero.Application.Common.Errors;
using HabitHero.Application.Common.Persistence;

namespace HabitHero.Application.Habits.Commands.DeleteHabit
{
    public sealed class DeleteHabitCommandHandler : ICommandHandler<DeleteHabitCommand, ErrorOr<Deleted>>
    {
        private readonly IUserRepository _userRepository;

        public DeleteHabitCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ErrorOr<Deleted>> Handle(DeleteHabitCommand request, CancellationToken cancellationToken)
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

            var deleteResult = user.DeleteHabit(habitId);
            if (deleteResult.IsError)
            {
                return deleteResult.Errors;
            }

            await _userRepository.SaveAsync(cancellationToken);

            return Result.Deleted;
        }
    }
}
