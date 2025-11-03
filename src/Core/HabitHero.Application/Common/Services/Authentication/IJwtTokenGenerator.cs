namespace HabitHero.Application.Common.Services.Authentication
{
    public interface IJwtTokenGenerator
    {
        Task<string> GenerateToken(Guid userId, string username, string email);
    }
}
