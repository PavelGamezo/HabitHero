using FluentValidation;

namespace HabitHero.Application.Habits.Commands.CompleteHabit
{
    public sealed class CompleteHabitCommandValidator : AbstractValidator<CompleteHabitCommand>
    {
        public CompleteHabitCommandValidator()
        {
            RuleFor(command => command.HabitId)
                .NotEmpty().WithMessage("Invalid identifier");

            RuleFor(command => command.UserId)
                .NotEmpty().WithMessage("Invalid user identifier");
        }
    }
}
