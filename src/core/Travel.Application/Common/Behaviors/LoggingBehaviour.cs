using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Travel.Application.Common.Behaviors
{
    /// <summary>
    /// The following code is for logging requests using the Microsoft.Extensions.Logging and MediatR.Pipeline namespaces.
    /// IRequestPreProcessor is an interface for a defined request to be pre-processed for a handler,
    /// while IRequest is a marker to represent a request with a response.
    /// </summary>
    /// <typeparam name="TRequest"></typeparam>
    public class LoggingBehaviour<TRequest> : IRequestPreProcessor<TRequest> where TRequest : IRequest<TRequest>
    {
        private readonly ILogger _logger;

        public LoggingBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogInformation("Travel Request: {@Request}",
            requestName, request);
        }
    }
}


