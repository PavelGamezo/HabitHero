using HabitHero.Domain.Users.Entities;

namespace HabitHero.Application.Common.Persistence
{
    public interface IRoleRepository
    {
        Task<Role?> GetRoleById(int roleId, CancellationToken cancellationToken);
    }
}
