using HabitHero.Domain.Habits.Enums;
using HabitHero.Domain.HabitTemplates;
using HabitHero.Domain.HabitTemplates.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HabitHero.Infrastructure.Persistence.Configurations
{
    public sealed class HabitTemplateConfiguration : IEntityTypeConfiguration<HabitTemplate>
    {
        public void Configure(EntityTypeBuilder<HabitTemplate> builder)
        {
            builder.ToTable("Templates")
                .HasKey(habitTemplate => habitTemplate.Id);

            var frequencyConverter = new ValueConverter<Frequency, string>(
                frequency => frequency.ToString(),
                frequency => Enum.Parse<Frequency>(frequency));

            var categoryConverter = new ValueConverter<Category, string>(
                category => category.ToString(),
                category => Enum.Parse<Category>(category));

            builder.Property(habitTemplate => habitTemplate.Frequency)
                .HasConversion(frequencyConverter);

            builder.Property(habitTemplate => habitTemplate.Category)
                .HasConversion(categoryConverter);

            builder.HasMany(habitTemplate => habitTemplate.Habits)
                .WithOne(habit => habit.HabitTemplate);
        }
    }
}
