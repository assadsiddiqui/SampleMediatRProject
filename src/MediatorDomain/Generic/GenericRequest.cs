using MediatR;

namespace MediatorDomain.Generic
{
    public class GenericRequest<TResponse> : IRequest<TResponse>
    {
        public int UserId { get; set; }
    }
}
