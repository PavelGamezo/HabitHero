namespace HabitHero.Api.Habits.DTOs
{
    public record CreateHabitRequest(
        string Title,
        string Description,
        string Frequency);
}
