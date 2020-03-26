using MediatR;

namespace MediatorDomain
{
    public class GreetingsRequest : IRequest<GreetingsResponse>
    {
        public int PersonId { get; set; }
    }
}