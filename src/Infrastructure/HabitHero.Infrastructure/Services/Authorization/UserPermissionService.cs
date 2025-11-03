using HabitHero.Application.Common.Services.Authorization;
using HabitHero.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HabitHero.Infrastructure.Services.Authorization
{
    public class UserPermissionService : IUserPermissionService
    {
        private readonly HabitHeroDbContext _context;

        public UserPermissionService(HabitHeroDbContext context)
        {
            _context = context;
        }

        public async Task<string[]> GetUserPermissionsAsync(Guid userId)
        {
            var permissions = await _context
                .Users
                .Where(user => user.Id == userId)
                .SelectMany(user => user.Roles)
                .SelectMany(role => role.Permissions)
                .Select(permission => permission.Name)
                .ToArrayAsync();

            return permissions;
        }
    }
}
