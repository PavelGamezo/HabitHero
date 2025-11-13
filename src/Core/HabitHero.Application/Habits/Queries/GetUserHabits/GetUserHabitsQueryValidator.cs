using FluentValidation;

namespace HabitHero.Application.Habits.Queries.GetUserHabits
{
    public sealed class GetUserHabitsQueryValidator : AbstractValidator<GetUserHabitsQuery>
    {
        public GetUserHabitsQueryValidator()
        {
            RuleFor(query => query.UserId)
                .NotEmpty().WithMessage("User identifier is empty");
        }
    }
}
