using ErrorOr;

namespace HabitHero.Application.Common.Errors
{
    public static class UserApplicationErrors
    {
        public static Error UserExistError = Error.Conflict(
            code: "Application.Common.Errors",
            description: "User has already exist");
    }
}
