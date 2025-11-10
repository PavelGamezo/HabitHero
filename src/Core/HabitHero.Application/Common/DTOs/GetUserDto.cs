namespace HabitHero.Application.Common.DTOs
{
    public record GetUserDto(
        Guid UserId,
        string Username,
        string Email,
        string Password,
        int Level,
        int Experience,
        int StreakCount);
}
