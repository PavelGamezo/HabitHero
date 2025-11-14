using ErrorOr;
using HabitHero.Application.Common.CQRS.Commands;

namespace HabitHero.Application.Habits.Commands.UpdateHabit
{
    public record class UpdateHabitCommand(
        Guid HabitId,
        string Title,
        string Description,
        Guid UserId) : ICommand<ErrorOr<Updated>>;
}
