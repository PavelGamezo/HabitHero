using ErrorOr;

namespace HabitHero.Application.Common.Errors
{
    public static class HabitApplicationErrors
    {
        public static Error InvalidHabitTitleError = Error.Validation(
            code: "Application.Common.Errors",
            description: "Invalid habit title value");

        public static Error InvalidHabitDescriptionError = Error.Validation(
            code: "Application.Common.Errors",
            description: "Invalid habit description value");

        public static Error InvalidHabitFrequencyError = Error.Validation(
            code: "Application.Common.Errors",
            description: "Invalid habit frequency value");

        public static Error NotFoundHabitError = Error.NotFound(
            code: "Application.Common.Errors",
            description: "Habit is not exist or wasn't found");
    }
}
