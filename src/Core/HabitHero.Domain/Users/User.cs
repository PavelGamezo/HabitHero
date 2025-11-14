using ErrorOr;
using HabitHero.Domain.Common;
using HabitHero.Domain.Habits;
using HabitHero.Domain.Users.Entities;
using HabitHero.Domain.Users.Errors;
using HabitHero.Domain.Users.Events;
using HabitHero.Domain.Users.ValueObjects;

namespace HabitHero.Domain.Users
{
    public class User : AggregateRoot<Guid>
    {
        public const int MaxExperienceValue = 100;

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

        public Email Email { get; private set; }

        public string PasswordHash { get; private set; }

        public Level Level { get; private set; }

        public Experience Experience { get; private set; }

        public StreakCount StreakCount { get; private set; }

        private readonly List<Habit> _habits = new();

        public IReadOnlyCollection<Habit> Habits => _habits.AsReadOnly();

        private readonly List<Role> _roles = new();

        public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

        public ErrorOr<Success> AddRole(Role role)
        {
            if (role is null)
            {
                return UserDomainErrors.NullRoleError;
            }

            if (_roles.Contains(role))
            {
                return UserDomainErrors.RoleExistError;
            }

            _roles.Add(role);

            return Result.Success;
        }

        public ErrorOr<Success> AddHabit(Habit habit)
        {
            if (habit is null)
            {
                return UserDomainErrors.NullHabitError;
            }

            if(_habits.Any(habitItem => habitItem.Title == habit.Title || habitItem == habit))
            {
                return UserDomainErrors.HabitExistError;
            }

            _habits.Add(habit);

            return Result.Success;
        }

        public ErrorOr<Deleted> DeleteHabit(Guid habitId)
        {
            var habit = _habits.FirstOrDefault(habit => habit.Id == habitId);
            if (habit is null)
            {
                return UserDomainErrors.NullHabitError;
            }

            _habits.Remove(habit);

            return Result.Deleted;
        }

        public bool IsUserHasHabit(Guid habitId)
        {
            if (habitId != Guid.Empty && _habits.Any(habit => habit.Id == habitId))
            {
                return true;
            }

            return false;
        }

        public void ChangeExperience()
        {
            if (Experience >= 90)
            {
                Experience += 10;
                Level += 1;
            }

            Experience += 10;
        }
    }
}
