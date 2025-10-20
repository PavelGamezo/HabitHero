using HabitHero.Domain.Common;

namespace HabitHero.Domain.Users.Events
{
    public sealed record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;
}
