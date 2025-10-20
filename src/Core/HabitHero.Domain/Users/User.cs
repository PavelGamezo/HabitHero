using HabitHero.Domain.Common;
using HabitHero.Domain.Habits;
using HabitHero.Domain.Users.Events;
using HabitHero.Domain.Users.ValueObjects;

namespace HabitHero.Domain.Users
{
    public class User : AggregateRoot<Guid>
    {
        private readonly List<Habit> _habits = new();

        public User(
            Guid id,
            string username,
            string email,
            string passwordHash,
            int level,
            int experience,
            int streakCount) : base(id)
        {
            Username = username;
            Email = email;
            PasswordHash = passwordHash;
            Level = level;
            Experience = experience;
            StreakCount = streakCount;

            AddDomainEvent(new UserCreatedDomainEvent(Id));
        }

        private User(Guid id) : base(id) { }

        public string Username { get; private set; }

        public string Email { get; private set; }

        public string PasswordHash { get; private set; }

        public Level Level { get; private set; }

        public Experience Experience { get; private set; }

        public StreakCount StreakCount { get; private set; }

        public IReadOnlyCollection<Habit> Habits => _habits.AsReadOnly();
    }
}
