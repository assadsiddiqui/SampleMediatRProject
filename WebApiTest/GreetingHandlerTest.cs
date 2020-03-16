using FluentAssertions;
using MediatorDomain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System.Threading;
using System.Threading.Tasks;

namespace WebApiTest
{
    [TestClass]
    public class GreetingHandlerTest
    {
        private IPersonRepository personRepository;
        private GreetingsHandler greetingHandler;

        [TestInitialize]
        public void Init()
        {
            personRepository = Substitute.For<IPersonRepository>();
            greetingHandler = new GreetingsHandler(personRepository);
        }

        [TestMethod]
        public async Task GreetingHandler_Should_Return_Correct_Greeting()
        {
            personRepository.GetPersonName(Arg.Any<int>()).Returns("John");
            var request = new GreetingsRequest { PersonId = 1 };

            var response = await greetingHandler.Handle(request, CancellationToken.None);

            response.Greeting.Should().Be("Hello John");
        }
    }
}
