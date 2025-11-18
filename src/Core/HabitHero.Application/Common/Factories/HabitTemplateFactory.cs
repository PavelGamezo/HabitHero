using ErrorOr;
using HabitHero.Application.Common.Errors;
using HabitHero.Domain.Common.Factory;
using HabitHero.Domain.Habits.Enums;
using HabitHero.Domain.HabitTemplates;
using HabitHero.Domain.HabitTemplates.Enums;

namespace HabitHero.Application.Common.Factories
{
    public class HabitTemplateFactory : IHabitTemplateFactory
    {
        public ErrorOr<HabitTemplate> CreateHabitTemplate(
            string title,
            string description,
            string frequency,
            string category)
        {
            var id = Guid.NewGuid();

            var frequencyList = Enum
                .GetValues<Frequency>()
                .Select(frequencyValue => frequencyValue.ToString());

            var categoryList = Enum
                .GetValues<Category>()
                .Select(category => category.ToString());

            if (!frequencyList.Contains(frequency))
            {
                return HabitTemplateApplicationErrors.InvalidFrequencyError;
            }

            if (!categoryList.Contains(category))
            {
                return HabitTemplateApplicationErrors.InvalidCategoryError;
            }

            if (string.IsNullOrEmpty(title))
            {
                return HabitTemplateApplicationErrors.InvalidHabitTitleError;
            }

            if (string.IsNullOrEmpty(description))
            {
                return HabitTemplateApplicationErrors.InvalidHabitTitleError;
            }

            return new HabitTemplate(
                id,
                title,
                description,
                Enum.Parse<Frequency>(frequency),
                Enum.Parse<Category>(category));
        }
    }
}
