using ErrorOr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace HabitHero.Application.Common.Behaviors
{
    public class LogginBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
        where TResponse : IErrorOr
    {
        private readonly ILogger<LogginBehavior<TRequest, TResponse>> _logger;

        public LogginBehavior(ILogger<LogginBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;    
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "[START] {@requestedName} {@requestDateTime}",
                request.GetType().Name,
                DateTime.UtcNow);

            var response = await next();

            if (response.IsError)
            {
                _logger.LogInformation(
                    "[END] Failure request with error {@RequestName}, {@Errors}, {@DateTimeUtc}",
                    request.GetType().Name,
                    response.Errors,
                    DateTime.UtcNow.ToString());

                return response;
            }

            _logger.LogInformation(
                "[END] {@requestedName} {@requestDateTime}",
                request.GetType().Name,
                DateTime.UtcNow);

            return response;
        }
    }
}
