namespace HabitHero.Application.Common.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(Guid userId, string username, string email);
    }
}
