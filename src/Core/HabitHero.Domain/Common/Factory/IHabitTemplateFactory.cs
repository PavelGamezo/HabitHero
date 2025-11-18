using ErrorOr;
using HabitHero.Domain.HabitTemplates;

namespace HabitHero.Domain.Common.Factory
{
    public interface IHabitTemplateFactory
    {
        ErrorOr<HabitTemplate> CreateHabitTemplate(string title, string description, string frequency, string category);
    }
}
