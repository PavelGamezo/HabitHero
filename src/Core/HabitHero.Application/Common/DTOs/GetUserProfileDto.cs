namespace HabitHero.Application.Common.DTOs
{
    public record GetUserProfileDto(
        Guid UserId,
        string Username,
        string Email,
        int Level,
        int Experience,
        int StreakCount);
}
