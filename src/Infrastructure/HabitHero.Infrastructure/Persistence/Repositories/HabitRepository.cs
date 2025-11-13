using HabitHero.Application.Common.Persistence;
using HabitHero.Domain.Habits;
using HabitHero.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace HabitHero.Infrastructure.Persistence.Repositories
{
    public class HabitRepository : IHabitRepository
    {
        private readonly HabitHeroDbContext _dbContext;

        public HabitRepository(HabitHeroDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddHabit(Habit habit)
        {
            _dbContext.Habits.Add(habit);
        }

        public void DeleteHabit(Habit habit)
        {
            _dbContext.Remove(habit);
        }

        public Task<Habit?> GetHabitByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return _dbContext.Habits
                .FirstOrDefaultAsync(habit => habit.Id == id, cancellationToken);
        }

        public async Task SaveAsync(CancellationToken cancellationToken)
        {
            await _dbContext.SaveChangesAsync();
        }

        public void UpdateHabit(Habit habit)
        {
            _dbContext.Update(habit);
        }
    }
}
