using ErrorOr;
using HabitHero.Domain.Common;
using HabitHero.Domain.Habits;
using HabitHero.Domain.Habits.Enums;
using HabitHero.Domain.HabitTemplates.Enums;
using HabitHero.Domain.Users;

namespace HabitHero.Domain.HabitTemplates
{
    public sealed class HabitTemplate : Entity<Guid>
    {
        public HabitTemplate(
            Guid id,
            string title,
            string description,
            Frequency frequency,
            Category category) : base(id)
        {

        }

        private HabitTemplate(Guid id) : base(id)
        {
        }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public Frequency Frequency { get; private set; }

        public Category Category { get; private set; }

        private readonly List<Habit> _habits = new();

        public IReadOnlyCollection<Habit> Habits => _habits.AsReadOnly();
    }
}
