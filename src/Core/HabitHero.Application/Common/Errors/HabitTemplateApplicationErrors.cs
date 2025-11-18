using ErrorOr;

namespace HabitHero.Application.Common.Errors
{
    public static class HabitTemplateApplicationErrors
    {
        public static Error InvalidCategoryError = Error.Validation(
            code: "Application.Common.Errors",
            description: "Invalid input category");

        public static Error InvalidFrequencyError = Error.Validation(
            code: "Application.Common.Errors",
            description: "Invalid habit frequency value");
        
        public static Error InvalidHabitTitleError = Error.Validation(
            code: "Application.Common.Errors",
            description: "Invalid habit title value");
        
        public static Error InvalidHabitDescriptionError = Error.Validation(
            code: "Application.Common.Errors",
            description: "Invalid habit description value");
    }
}
