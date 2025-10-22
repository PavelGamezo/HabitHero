using HabitHero.Domain.Users;
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

            builder.OwnsOne(user => user.Email, ownedType =>
            {
                ownedType.Property(email => email.Value)
                    .HasColumnName("Email");
            });

            builder.OwnsOne(user => user.Experience, ownedType =>
            {
                ownedType.Property(experience => experience.Value)
                    .HasColumnName("Experience");
            });

            builder.OwnsOne(user => user.Level, ownedType =>
            {
                ownedType.Property(level => level.Value)
                    .HasColumnName("Level");
            });

            builder.OwnsOne(user => user.StreakCount, ownedType =>
            {
                ownedType.Property(streakCount => streakCount.Value)
                    .HasColumnName("StreakCount");
            });

            builder.HasMany(user => user.Habits)
                .WithOne(habit => habit.User);
        }
    }
}
