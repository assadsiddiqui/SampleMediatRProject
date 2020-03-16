using MediatR.Pipeline;
using System.Threading;
using System.Threading.Tasks;

namespace MediatorDomain
{
    public class GreetNextGuyHandler //: IRequestPostProcessor<GreetingsRequest, GreetingsResponse>
    {
        private readonly IPersonRepository personRepository;

        public GreetNextGuyHandler(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public async Task Process(GreetingsRequest request, GreetingsResponse response, CancellationToken cancellationToken)
        {
            var name = await personRepository.GetPersonName(request.PersonId + 1);
            response.Greeting = $"{response.Greeting}, {name}";
            
        }
    }
}
