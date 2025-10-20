using ErrorOr;
using HabitHero.Domain.Common;
using HabitHero.Domain.Users.Errors;

namespace HabitHero.Domain.Users.ValueObjects
{
    public sealed class Experience : ValueObject
    {
        public int Value { get; private set; }

        public Experience(int value)
        {
            Value = value;
        }

        public static ErrorOr<Experience> Create(int value)
        {
            if (value < 0 && value > 100)
            {
                return UserDomainErrors.IncorrectExperienceValue;
            }

            return new Experience(value);
        }

        public void UpgradeExperience() 
            => Value += 10;
        public void DowngradeExperience() 
            => Value -= 10;

        public void ClearExperience()
            => Value = 0;

        public static implicit operator int(Experience experience) 
            => experience.Value;

        public static implicit operator Experience(int value)
            => new Experience(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
