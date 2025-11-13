using ErrorOr;
using HabitHero.Application.Common.CQRS.Commands;
using HabitHero.Application.Common.Errors;
using HabitHero.Application.Common.Persistence;
using HabitHero.Domain.Common.Factory;
using HabitHero.Domain.Habits.Enums;

namespace HabitHero.Application.Habits.Commands.CreateHabit
{
    public sealed class CreateHabitCommandHandler : ICommandHandler<CreateHabitCommand, ErrorOr<Success>>
    {
        private readonly IHabitRepository _habitRepository;
        private readonly IUserRepository _userRepository;
        private readonly IHabitFactory _habitFactory;

        public CreateHabitCommandHandler(
            IHabitRepository habitRepository,
            IUserRepository userRepository,
            IHabitFactory habitFactory)
        {
            _habitRepository = habitRepository;
            _userRepository = userRepository;
            _habitFactory = habitFactory;
        }

        public async Task<ErrorOr<Success>> Handle(CreateHabitCommand request, CancellationToken cancellationToken)
        {
            var (title, description, frequency, userId) = request;

            var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
            if (user is null)
            {
                return UserApplicationErrors.NotFoundUserError;
            }

            var factoryResult = _habitFactory.CreateHabit(title, description, frequency);
            if (factoryResult.IsError)
            {
                return factoryResult.Errors;
            }

            var habit = factoryResult.Value;

            _habitRepository.AddHabit(habit);

            user.AddHabit(habit);

            await _habitRepository.SaveAsync(cancellationToken);

            return Result.Success;
        }
    }
}
