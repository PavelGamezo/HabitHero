using ErrorOr;
using HabitHero.Application.Common.CQRS.Commands;
using System.Windows.Input;

namespace HabitHero.Application.Habits.Commands.CreateHabit
{
    public record CreateHabitCommand(
        string Title,
        string Description,
        string Frequency,
        Guid UserId) : ICommand<ErrorOr<Success>>;
}
