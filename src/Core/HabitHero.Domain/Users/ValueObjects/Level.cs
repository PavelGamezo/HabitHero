using ErrorOr;
using HabitHero.Domain.Common;
using HabitHero.Domain.Users.Errors;

namespace HabitHero.Domain.Users.ValueObjects
{
    public class Level : ValueObject
    {
        public int Value { get; private set; }

        public Level(int value)
        {
            Value = value;
        }

        public static ErrorOr<Level> Create(int value)
        {
            if (value < 0)
            {
                return UserDomainErrors.IncorrectLevelValue;
            }

            return new Level(value);
        }

        public static implicit operator int(Level level)
            => level.Value;

        public static implicit operator Level(int value)
            => new Level(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            throw new NotImplementedException();
        }
    }
}
