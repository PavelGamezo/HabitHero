using HabitHero.Domain.Users;
using HabitHero.Domain.Users.Entities;
using HabitHero.Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HabitHero.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(x => x.Id);

            var emailConverter = new ValueConverter<Email, string>(
                email => email.Value,
                email => Email.Create(email).Value);

            var levelConverter = new ValueConverter<Level, int>(
                level => level.Value,
                level => Level.Create(level).Value);

            var experienceConverter = new ValueConverter<Experience, int>(
                experience => experience.Value,
                experience => Experience.Create(experience).Value);

            var streakCount = new ValueConverter<StreakCount, int>(
                streakCount => streakCount.Value,
                streakCount => StreakCount.Create(streakCount).Value);

            builder.Property(user => user.Email)
                   .HasConversion(emailConverter);

            builder.Property(user => user.Level)
                .HasConversion(levelConverter);
            
            builder.Property(user => user.Experience)
                .HasConversion(experienceConverter);

            builder.Property(user => user.StreakCount)
                .HasConversion(streakCount);

            builder.HasMany(user => user.Habits)
                .WithOne(habit => habit.User);

            builder.HasMany(user => user.Roles)
                .WithMany(role => role.Users)
                .UsingEntity<UserRole>(
                    r => r.HasOne<Role>().WithMany().HasForeignKey(ur => ur.RoleId),
                    l => l.HasOne<User>().WithMany().HasForeignKey(ur => ur.UserId));
        }
    }
}
