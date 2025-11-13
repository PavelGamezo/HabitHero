using HabitHero.Domain.Common;
using HabitHero.Domain.Habits.Enums;
using HabitHero.Domain.Users;

namespace HabitHero.Domain.Habits
{
    public class Habit : AggregateRoot<Guid>
    {
        public Habit(
            Guid id,
            string title,
            string description,
            Frequency frequency) : base(id)
        {
            Title = title;
            Description = description;
            Frequency = frequency;
            StartDate = DateTime.UtcNow;
            IsArchived = false;
        }

        public string Title { get; private set; }

        public string? Description { get; private set; }

        public DateTime? StartDate { get; private set; }

        public Frequency Frequency { get; private set; }

        public bool IsArchived { get; private set; }

        public User? User { get; private set; }
    }
}
