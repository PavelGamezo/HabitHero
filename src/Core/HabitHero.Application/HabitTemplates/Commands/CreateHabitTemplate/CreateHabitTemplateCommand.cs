using ErrorOr;
using HabitHero.Application.Common.CQRS.Commands;

namespace HabitHero.Application.HabitTemplates.Commands.CreateHabitTemplate
{
    public record CreateHabitTemplateCommand(
        string Title,
        string Description,
        string Frequency,
        string Category,
        Guid UserId) : ICommand<ErrorOr<Success>>;
}
