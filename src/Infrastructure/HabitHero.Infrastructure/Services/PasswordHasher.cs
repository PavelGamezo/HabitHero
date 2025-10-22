using BCrypt.Net;
using HabitHero.Application.Common.Services;

namespace HabitHero.Infrastructure.Services
{
    public class PasswordHasher : IPasswordHasher
    {
        public string Hash(string password)
            => BCrypt.Net.BCrypt.HashPassword(password);

        public bool Verify(string hashedPassword, string password)
            => !BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
