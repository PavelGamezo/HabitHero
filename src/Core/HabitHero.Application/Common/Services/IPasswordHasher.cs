namespace HabitHero.Application.Common.Services
{
    public interface IPasswordHasher
    {
        string Hash(string password);

        bool Verify(string hashedPassword, string password);
    }
}
