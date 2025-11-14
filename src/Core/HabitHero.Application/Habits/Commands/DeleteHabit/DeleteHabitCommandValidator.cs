using FluentValidation;

namespace HabitHero.Application.Habits.Commands.DeleteHabit
{
    public sealed class DeleteHabitCommandValidator : AbstractValidator<DeleteHabitCommand>
    {
        public DeleteHabitCommandValidator()
        {
            RuleFor(command => command.HabitId)
                .NotEmpty().WithMessage("Invalid identifier");

            RuleFor(command => command.UserId)
                .NotEmpty().WithMessage("Invalid user identifier");
        }
    }
}
