using ErrorOr;

namespace HabitHero.Domain.Habits.Errors
{
    public static class HabitDomainErrors
    {
        public static Error HabitCompletedError = Error.Conflict(
            code: "Domain.Habits.Errors",
            description: "Habit has already completed");

        public static Error InvalidTitleValueError = Error.Validation(
            code: "Domain.Habits.Errors",
            description: "Title is invalid");

        public static Error InvalidDescriptionValueError = Error.Validation(
            code: "Domain.Habits.Errors",
            description: "Title is invalid");
    }
}
