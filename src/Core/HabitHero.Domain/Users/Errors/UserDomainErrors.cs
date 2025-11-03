using ErrorOr;

namespace HabitHero.Domain.Users.Errors
{
    public static class UserDomainErrors
    {
        public static Error IncorrectExperienceValueError = Error.Validation(
            code: "Domain.Users.Errors",
            description: "Experience value must have valid number");

        public static Error IncorrectLevelValueError = Error.Validation(
            code: "Domain.Users.Errors",
            description: "Level value must have valid number");

        public static Error IncorrectStreakCountValueError = Error.Validation(
            code: "Domain.Users.Errors",
            description: "StreakCount value must have valid number");

        public static Error EmailIsNullOrEmptyError = Error.Validation(
            code: "Domain.Users.Errors",
            description: "Email can't be null or empty");

        public static Error IncorrectEmailValueError = Error.Validation(
            code: "Domain.Users.Errors",
            description: "Email can't be null or empty");

        public static Error RoleExistError = Error.Conflict(
            code: "Domain.Users.Errors",
            description: "User already has the same role");
    }
}
