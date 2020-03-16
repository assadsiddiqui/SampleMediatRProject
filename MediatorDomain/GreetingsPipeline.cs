using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;

namespace MediatorDomain
{
    public class GreetingsPipeline : IPipelineBehavior<GreetingsRequest, GreetingsResponse>
    {
        private readonly IEnumerable<IValidator<GreetingsRequest>> _validators;

        public GreetingsPipeline(IEnumerable<IValidator<GreetingsRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<GreetingsResponse> Handle(GreetingsRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<GreetingsResponse> next)
        {
            var context = new ValidationContext(request);
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }
            var response = await next();
            return response;
        }

        /*
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public GreetingsPipeline(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var context = new ValidationContext(request);
            var failures = _validators
                .Select(v => v.Validate(request))
                .SelectMany(result => result.Errors)
                .Where(f => f != null)
                .ToList();

            var response = next();
            return response;
        }
        */
    }
}
