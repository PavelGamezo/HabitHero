using ErrorOr;
using HabitHero.Application.Common.CQRS.Commands;

namespace HabitHero.Application.Habits.Commands.DeleteHabit
{
    public record DeleteHabitCommand(Guid HabitId, Guid UserId) : ICommand<ErrorOr<Deleted>>;
}
