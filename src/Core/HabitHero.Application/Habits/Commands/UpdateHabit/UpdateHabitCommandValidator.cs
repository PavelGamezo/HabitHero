using FluentValidation;

namespace HabitHero.Application.Habits.Commands.UpdateHabit
{
    public sealed class UpdateHabitCommandValidator : AbstractValidator<UpdateHabitCommand>
    {
        public UpdateHabitCommandValidator()
        {
            RuleFor(command => command.HabitId)
                .NotEmpty().WithMessage("Invalid identifier");

            RuleFor(command => command.UserId)
                .NotEmpty().WithMessage("Invalid user identifier");

            RuleFor(command => command.Title)
                .NotEmpty().WithMessage("Title is required")
                .Length(1, 100).WithMessage("Title must have more than 1 and less than 100 characters"); ;

            RuleFor(command => command.Description)
                .NotEmpty().WithMessage("Description is required")
                .Length(1, 1000).WithMessage("Description must have more than 1 and less than 1000 characters");
        }
    }
}
