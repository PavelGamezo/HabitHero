using ErrorOr;
using HabitHero.Domain.Common;
using HabitHero.Domain.Users.Errors;

namespace HabitHero.Domain.Users.ValueObjects
{
    public class StreakCount : ValueObject
    {
        public int Value { get; private set; }

        public StreakCount(int value)
        {
            Value = value;
        }

        public static ErrorOr<StreakCount> Create(int value)
        {
            if (value < 0)
            {
                return UserDomainErrors.IncorrectStreakCountValueError;
            }

            return new StreakCount(value);
        }

        public static StreakCount CreateDefaultValue()
        {
            return new StreakCount(0);
        }

        public static implicit operator StreakCount(int value) 
            => new StreakCount(value);

        public static implicit operator int(StreakCount streakCount)
            => streakCount.Value;

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
