using HabitHero.Application.Common.Persistence;
using HabitHero.Domain.Users.Entities;
using HabitHero.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HabitHero.Infrastructure.Persistence.Repositories
{
    public class RoleRepository : IRoleRepository
    {
        private readonly HabitHeroDbContext _context;

        public RoleRepository(HabitHeroDbContext context)
        {
            _context = context;
        }

        public async Task<Role?> GetRoleById(int roleId, CancellationToken cancellationToken)
        {
            return await _context.Roles.FirstOrDefaultAsync(role => role.Id == roleId, cancellationToken);
        }
    }
}
