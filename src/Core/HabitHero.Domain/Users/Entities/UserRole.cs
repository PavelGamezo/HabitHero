using HabitHero.Domain.Common;

namespace HabitHero.Domain.Users.Entities
{
    public class UserRole
    {
        public Guid UserId { get; set; }

        public int RoleId { get; set; }
    }
}
