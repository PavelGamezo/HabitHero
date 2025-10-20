using HabitHero.Domain.Habits;
using HabitHero.Domain.Users;
using HabitHero.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HabitHero.Infrastructure.Persistence.Contexts
{
    public class HabitHeroDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Habit> Habits { get; set; }

        public HabitHeroDbContext(DbContextOptions options) :base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userConfiguration = new UserConfiguration();

            modelBuilder.ApplyConfiguration(userConfiguration);

            base.OnModelCreating(modelBuilder);
        }
    }
}
