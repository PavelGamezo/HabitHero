using HabitHero.Application.Common.CQRS.Commands;
using ErrorOr;

namespace HabitHero.Application.Users.Commands.RegisterUser
{
    public record RegisterUserCommand(
        string Username,
        string Email,
        string Password) : ICommand<ErrorOr<Success>>;
}
