using HabitHero.Domain.Common;
using HabitHero.Domain.Users;

namespace HabitHero.Domain.Habits
{
    public class Habit : AggregateRoot<Guid>
    {
        public Habit(Guid id) : base(id)
        {
        }

        public User User { get; set; }
    }
}
