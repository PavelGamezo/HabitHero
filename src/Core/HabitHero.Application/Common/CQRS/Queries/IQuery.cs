using MediatR;

namespace HabitHero.Application.Common.CQRS.Queries
{
    public interface IQuery : IRequest
    {
    }

    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}
