using ErrorOr;
using HabitHero.Application.Common.Services;
using HabitHero.Domain.Common.Factory;
using HabitHero.Domain.Users;
using HabitHero.Domain.Users.ValueObjects;

namespace HabitHero.Application.Common.Factories
{
    public class UserFactory : IUserFactory
    {
        private readonly IPasswordHasher _passwordHasher;

        public UserFactory(IPasswordHasher passwordHasher)
        {
            _passwordHasher = passwordHasher;
        }

        public ErrorOr<User> CreateUser(string username, string email, string password)
        {
            var id = Guid.NewGuid();
            
            var emailResult = Email.Create(email);
            if (emailResult.IsError)
            {
                return emailResult.Errors;
            }

            var hashedPassword = _passwordHasher.Hash(password);
            var level = Level.CreateDefaultValue();
            var experience = Experience.CreateDefaultValue();
            var strickCount = StreakCount.CreateDefaultValue();

            var user = new User(
                id,
                username,
                emailResult.Value,
                hashedPassword,
                level,
                experience,
                strickCount);

            return user;
        }
    }
}
