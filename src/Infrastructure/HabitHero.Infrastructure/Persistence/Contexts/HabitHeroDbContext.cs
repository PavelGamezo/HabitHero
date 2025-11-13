using HabitHero.Domain.Habits;
using HabitHero.Domain.Users;
using HabitHero.Domain.Users.Entities;
using HabitHero.Infrastructure.Common.Options;
using HabitHero.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HabitHero.Infrastructure.Persistence.Contexts
{
    public class HabitHeroDbContext(DbContextOptions options,
            IOptions<AuthorizationOptions> authorizationOptions) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Permission> Permissions { get; set; }

        public DbSet<Habit> Habits { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userConfiguration = new UserConfiguration();
            var roleConfiguration = new RoleConfiguration();
            var rolePermissionConfiguration = new RolePermissionConfiguration(authorizationOptions.Value);
            var permissionConfiguration = new PermissionConfiguration();
            var habitConfiguration = new HabitConfiguration();

            modelBuilder.ApplyConfiguration(userConfiguration);
            modelBuilder.ApplyConfiguration(roleConfiguration);
            modelBuilder.ApplyConfiguration(rolePermissionConfiguration);
            modelBuilder.ApplyConfiguration(permissionConfiguration);
            modelBuilder.ApplyConfiguration(habitConfiguration);

            base.OnModelCreating(modelBuilder);
        }
    }
}
