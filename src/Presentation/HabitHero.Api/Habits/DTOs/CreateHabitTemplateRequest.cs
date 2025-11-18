namespace HabitHero.Api.Habits.DTOs
{
    public record CreateHabitTemplateRequest(
        string Title,
        string Description,
        string Frequency);
}
