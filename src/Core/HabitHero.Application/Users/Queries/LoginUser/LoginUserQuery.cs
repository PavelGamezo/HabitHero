using ErrorOr;
using HabitHero.Application.Common.CQRS.Queries;

namespace HabitHero.Application.Users.Queries.LoginUser
{
    public record LoginUserQuery(string Email, string Password) : IQuery<ErrorOr<string>>;
}
