using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace MediatorDomain
{
    public class GreetingsHandler : IRequestHandler<GreetingsRequest, GreetingsResponse>
    {
        private readonly IPersonRepository personRepository;

        public GreetingsHandler(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task<GreetingsResponse> Handle(GreetingsRequest request, CancellationToken cancellationToken)
        {
            var name = await personRepository.GetPersonName(request.PersonId);
            return new GreetingsResponse { Greeting = $"Hello {name}" };
        }
    }
}
