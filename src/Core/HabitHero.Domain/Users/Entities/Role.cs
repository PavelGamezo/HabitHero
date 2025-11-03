namespace HabitHero.Domain.Users.Entities
{
    public class Role
    {
        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; init; }

        public string Name { get; init; } = string.Empty;

        private readonly List<User>? _users = new();

        public IReadOnlyCollection<User>? Users => _users;

        private readonly List<Permission> _permissions = new();

        public IReadOnlyCollection<Permission> Permissions => _permissions;
    }
}
