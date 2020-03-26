using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using MediatR;

namespace MediatorDomain.Generic
{
    public class GenericPrehandler<TRequest, TResponse> : IRequestPreProcessor<TRequest>
        where TRequest : GenericRequest<TResponse>
    {
        public Task Process(TRequest request, CancellationToken cancellationToken)
        {
            request.UserId = 1;
            return Task.FromResult(0);
        }
    }
}
