using ErrorOr;
using HabitHero.Domain.Common;
using HabitHero.Domain.Habits.Enums;
using HabitHero.Domain.Habits.Errors;
using HabitHero.Domain.Users;
using HabitHero.Domain.Users.Errors;

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

        public DateTime? DateCompleted { get; private set; }

        public bool IsCompleted { get; private set; }

        public User? User { get; private set; }

        public ErrorOr<Success> Complete()
        {
            if (!DateCompleted.HasValue && IsCompleted == false)
            {
                DateCompleted = DateTime.UtcNow;
                IsCompleted = true;

                return Result.Success;
            }

            if (IsCompleted)
            {
                return HabitDomainErrors.HabitCompletedError;
            }

            return Result.Success;
        }

        public ErrorOr<Updated> ChangeInfo(string title, string description)
        {
            if (title.Length > 100)
            {
                return HabitDomainErrors.InvalidTitleValueError;
            }

            if (description.Length > 1000)
            {
                return HabitDomainErrors.InvalidDescriptionValueError;
            }

            Title = title;
            Description = description;
        }
    }
}
