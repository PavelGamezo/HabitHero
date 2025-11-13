using HabitHero.Domain.Habits;

namespace HabitHero.Application.Common.Persistence
{
    public interface IHabitRepository
    {
        Task<Habit?> GetHabitByIdAsync(Guid id, CancellationToken cancellationToken);

        void AddHabit(Habit habit);

        void DeleteHabit(Habit habit);

        void UpdateHabit(Habit habit);

        Task SaveAsync(CancellationToken cancellationToken);
    }
}
