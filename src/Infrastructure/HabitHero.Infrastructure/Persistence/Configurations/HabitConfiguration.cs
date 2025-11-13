using HabitHero.Domain.Habits;
using HabitHero.Domain.Habits.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HabitHero.Infrastructure.Persistence.Configurations
{
    public sealed class HabitConfiguration : IEntityTypeConfiguration<Habit>
    {
        public void Configure(EntityTypeBuilder<Habit> builder)
        {
            builder.ToTable("Habits");

            builder.HasKey(habit => habit.Id);

            var frequencyConverter = new ValueConverter<Frequency, string>(
                frequency => frequency.ToString(),
                frequency => Enum.Parse<Frequency>(frequency));

            builder.Property(habit => habit.Frequency)
                .HasConversion(frequencyConverter);

            builder.HasOne(habit => habit.User)
                .WithMany(user => user.Habits);
        }
    }
}
