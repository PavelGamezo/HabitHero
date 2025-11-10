using HabitHero.Domain.Users;

namespace HabitHero.Application.Common.DTOs.Configurations
{
    public static class UserMapping
    {
        private static readonly Dictionary<Type, Delegate> _mappers = new()
        {
            [typeof(GetUserDto)] = (Func<User, GetUserDto>)(user => new GetUserDto
            (
                user.Id,
                user.Username,
                user.Email,
                user.PasswordHash,
                user.Level,
                user.Experience,
                user.StreakCount
            )),

            [typeof(GetUserProfileDto)] = (Func<User, GetUserProfileDto>)(user => new GetUserProfileDto
            (
                user.Id,
                user.Username,
                user.Email,
                user.Level,
                user.Experience,
                user.StreakCount
            ))
        };

        public static T Map<T>(this User user)
        {
            if (_mappers.TryGetValue(typeof(T), out var mapper))
            {
                return ((Func<User, T>)mapper)(user);
            }

            throw new InvalidOperationException($"Mapping for {typeof(T).Name} is not registered.");
        }
    }
}
