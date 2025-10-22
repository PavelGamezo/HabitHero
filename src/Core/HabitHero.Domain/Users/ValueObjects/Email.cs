using ErrorOr;
using HabitHero.Domain.Common;
using HabitHero.Domain.Users.Errors;
using System.Text.RegularExpressions;

namespace HabitHero.Domain.Users.ValueObjects
{
    public class Email : ValueObject
    {
        public string Value { get; private set; } = null!;

        public Email(string value)
        {
            Value = value;
        }

        public static ErrorOr<Email> Create(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return UserDomainErrors.EmailIsNullOrEmptyError;
            }

            if (!Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                return UserDomainErrors.IncorrectEmailValueError;
            }

            return new Email(value);
        }

        public static implicit operator string(Email email) 
            => email.Value;

        public static implicit operator Email(string value)
            => new Email(value);

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
