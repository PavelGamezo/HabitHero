using ErrorOr;
using HabitHero.Domain.Users;

namespace HabitHero.Domain.Common.Factory
{
    public interface IUserFactory
    {
        ErrorOr<User> CreateUser(string username, string email, string password);
    }
}
