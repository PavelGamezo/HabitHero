using HabitHero.Domain.Habits;
using HabitHero.Domain.Users;

namespace HabitHero.Application.Common.DTOs.Configurations
{
    public static class HabitMapping
    {
        private static readonly Dictionary<Type, Delegate> _mappers = new()
        {
            [typeof(HabitDto)] = (Func<Habit, HabitDto>)(habit => new HabitDto
            (
                Id: habit.Id,
                Title: habit.Title,
                Description: habit.Description,
                Frequency: habit.Frequency.ToString(),
                StartDate: habit.StartDate.Value
            )),
        };

        public static T Map<T>(this Habit habit)
        {
            if (_mappers.TryGetValue(typeof(T), out var mapper))
            {
                return ((Func<Habit, T>)mapper)(habit);
            }

            throw new InvalidOperationException($"Mapping for {typeof(T).Name} is not registered.");
        }
    }
}
