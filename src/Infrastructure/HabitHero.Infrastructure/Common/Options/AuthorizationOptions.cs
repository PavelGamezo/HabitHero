namespace HabitHero.Infrastructure.Common.Options
{
    public class AuthorizationOptions
    {
        public const string SectionName = "AuthorizationOptions";

        public RolePermissions[] RolePermissions { get; set; } = [];
    }

    public class RolePermissions
    {
        public string Role { get; init; } = string.Empty!;

        public string[] Permissions { get; init; } = [];
    }
}
