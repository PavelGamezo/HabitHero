using ErrorOr;
using HabitHero.Application.Common.Errors;
using HabitHero.Domain.Common.Factory;
using HabitHero.Domain.Habits;
using HabitHero.Domain.Habits.Enums;

namespace HabitHero.Application.Common.Factories
{
    public class HabitFactory : IHabitFactory
    {
        public ErrorOr<Habit> CreateHabit(string title, string description, string frequency)
        {
            var id = Guid.NewGuid();
            var frequencyList = Enum
                .GetValues<Frequency>()
                .Select(frequencyValue => frequencyValue.ToString());

            if (!frequencyList.Contains(frequency))
            {
                return HabitApplicationErrors.InvalidHabitFrequencyError;
            }

            if (string.IsNullOrEmpty(title))
            {
                return HabitApplicationErrors.InvalidHabitTitleError;
            }

            if (string.IsNullOrEmpty(description))
            {
                return HabitApplicationErrors.InvalidHabitTitleError;
            }

            return new Habit(id, title, description, Enum.Parse<Frequency>(frequency));
        }
    }
}
