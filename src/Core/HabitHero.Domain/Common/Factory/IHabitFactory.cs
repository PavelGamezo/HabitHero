using ErrorOr;
using HabitHero.Domain.Habits;
using HabitHero.Domain.Habits.Enums;

namespace HabitHero.Domain.Common.Factory
{
    public interface IHabitFactory
    {
        ErrorOr<Habit> CreateHabit(string title, string description, Frequency frequency);
    }
}
