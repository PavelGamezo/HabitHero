using HabitHero.Application.Common.Persistence;
using HabitHero.Domain.Users;
using HabitHero.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HabitHero.Infrastructure.Persistence.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HabitHeroDbContext _dbContext;

        public UserRepository(HabitHeroDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(User user)
        {
            _dbContext.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _dbContext.Users.Remove(user);
        }

        public Task<User?> GetUserByEmailAsync(string email, CancellationToken cancellationToken)
        {
            return _dbContext.Users
                .FirstOrDefaultAsync(user => user.Email == email, cancellationToken);
        }

        public Task<User?> GetUserByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _dbContext.Users
                .Include(user => user.Roles)
                .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        public Task<User?> GetUserWithHabitsByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _dbContext.Users
                .Include(user => user.Habits)
                .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        public Task<User?> GetUserWithHabitsByIdWithNoTrackingAsync(Guid id, CancellationToken cancellationToken)
        {
            return _dbContext.Users
                .Include(user => user.Habits)
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        public Task<User?> GetUserByIdWithNoTrackingAsync(Guid id, CancellationToken cancellationToken)
        {
            return _dbContext.Users
                .Include(user => user.Roles)
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
        }

        public async Task<bool> IsUserExistAsync(string email, string username, CancellationToken cancellationToken)
        {
            var user = await GetUserByEmailAsync(email, cancellationToken);
            if (user is null || user.Username != username)
            {
                return false;
            }

            return true;
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void UpdateUser(User user)
        {
            _dbContext.Update(user);
        }
    }
}