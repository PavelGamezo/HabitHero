using ErrorOr;
using HabitHero.Domain.Habits;

namespace HabitHero.Domain.Common.Factory
{
    public interface IHabitFactory
    {
        ErrorOr<Habit> CreateHabit(string title, string description, string frequency);
    }
}
