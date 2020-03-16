using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;

namespace MediatorDomain
{
    public class VerifyPerson //: IRequestPreProcessor<GreetingsRequest>
    {
        private readonly IPersonRepository personRepository;
        public VerifyPerson(IPersonRepository personRepository)
        {
            this.personRepository = personRepository;
        }

        public Task Process(GreetingsRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var personId = personRepository.GetPersonName(request.PersonId);
                return Task.FromResult(0);
            }
            catch(ArgumentNullException ex)
            {
                throw new Exception($"System can't find user with Id {request.PersonId}. Error: {ex.Message}");
            }
        }
    }
}
