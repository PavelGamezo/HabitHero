using FluentValidation;

namespace HabitHero.Application.HabitTemplates.Commands.CreateHabitTemplate
{
    public class CreateHabitTemplateCommandValidator : AbstractValidator<CreateHabitTemplateCommand>
    {
        public CreateHabitTemplateCommandValidator()
        {
            RuleFor(command => command.Title)
                .NotEmpty().WithMessage("Title is required")
                .Length(1, 100).WithMessage("Title must have more than 1 and less than 100 characters"); ;

            RuleFor(command => command.Description)
                .NotEmpty().WithMessage("Description is required")
                .Length(1, 1000).WithMessage("Description must have more than 1 and less than 1000 characters");

            RuleFor(command => command.Frequency)
                .NotEmpty().WithMessage("Frequency is required");

            RuleFor(command => command.UserId)
                .NotEmpty().WithMessage("Invalid user identifier");
        }
    }
}
