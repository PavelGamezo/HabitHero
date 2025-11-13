namespace HabitHero.Application.Common.DTOs
{
    public record HabitDto(
        Guid Id,
        string Title,
        string Description,
        string Frequency,
        DateTime StartDate);
}
