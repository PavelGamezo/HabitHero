using ErrorOr;
using HabitHero.Application.Common.CQRS.Commands;

namespace HabitHero.Application.Habits.Commands.CompleteHabit
{
    public record CompleteHabitCommand(
        Guid HabitId,
        Guid UserId) : ICommand<ErrorOr<Success>>;
}
