namespace HabitHero.Domain.Users.Entities
{
    public sealed class Permission
    {
        private readonly List<Role> _roles = new();

        public int Id { get; init; }

        public string Name { get; init; } = string.Empty;

        public IReadOnlyCollection<Role> Roles => _roles.AsReadOnly();

        public Permission(int id, string name)
        {
            Name = name;
            Id = id;
        }
    }
}
