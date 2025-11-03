using ErrorOr;

namespace HabitHero.Application.Common.Errors
{
    public static class UserApplicationErrors
    {
        public static Error UserExistError = Error.Conflict(
            code: "Application.Common.Errors",
            description: "User has already exist.");

        public static Error NotFoundUserError = Error.NotFound(
            code: "Application.Common.Errors",
            description: "User is not exist.");

        public static Error InvalidUserPasswordError = Error.Conflict(
            code: "Application.Common.Errors",
            description: "Incorrect password or email.");

        public static Error NotFoundRoleError = Error.NotFound(
            code: "Application.Common.Errors",
            description: "Role is not exist.");
    }
}
