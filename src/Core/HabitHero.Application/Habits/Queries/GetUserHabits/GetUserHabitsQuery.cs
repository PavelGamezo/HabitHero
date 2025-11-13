using ErrorOr;
using HabitHero.Application.Common.CQRS.Queries;
using HabitHero.Application.Common.DTOs;

namespace HabitHero.Application.Habits.Queries.GetUserHabits
{
    public record GetUserHabitsQuery(Guid UserId) : IQuery<ErrorOr<List<HabitDto>>>;
}
