namespace HabitHero.Infrastructure.Common.Options
{
    public class ConnectionString
    {
        public const string SectionName = "ConnectionString";

        public string Value { get; set; } = null!;
    }
}
