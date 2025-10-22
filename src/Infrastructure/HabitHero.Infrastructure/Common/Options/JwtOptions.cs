namespace HabitHero.Infrastructure.Common.Options
{
    public class JwtOptions
    {
        public const string SectionName = "JwtOptions";

        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public double Expires { get; set; } = 0;
        public string SecurityKey { get; set; } = null!;
    }
}
