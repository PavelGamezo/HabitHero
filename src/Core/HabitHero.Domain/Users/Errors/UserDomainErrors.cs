using ErrorOr;

namespace HabitHero.Domain.Users.Errors
{
    public static class UserDomainErrors
    {
        public static Error IncorrectExperienceValue = Error.Validation(
            code: "Domain.Users.Errors",
            description: "Experience value must have valid number");

        public static Error IncorrectLevelValue = Error.Validation(
            code: "Domain.Users.Errors",
            description: "Experience value must have valid number");

        public static Error IncorrectStreakCountValue = Error.Validation(
            code: "Domain.Users.Errors",
            description: "Experience value must have valid number");
    }
}
