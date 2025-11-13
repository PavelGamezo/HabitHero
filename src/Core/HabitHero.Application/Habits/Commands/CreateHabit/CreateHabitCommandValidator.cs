using FluentValidation;

namespace HabitHero.Application.Habits.Commands.CreateHabit
{
    public class CreateHabitCommandValidator : AbstractValidator<CreateHabitCommand>
    {
        public CreateHabitCommandValidator()
        {
            RuleFor(command => command.Title)
                .NotEmpty().WithMessage("Title is required")
                .Length(1, 100).WithMessage("Title must have more than 1 and less than 100 characters"); ;

            RuleFor(command => command.Description)
                .NotEmpty().WithMessage("Description is required")
                .Length(1, 1000).WithMessage("Description must have more than 1 and less than 1000 characters");

            RuleFor(command => command.Frequency)
                .NotEmpty().WithMessage("Frequency is required");
        }
    }
}
