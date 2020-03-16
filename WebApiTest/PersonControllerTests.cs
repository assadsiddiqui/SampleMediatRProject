using FluentAssertions;
using MediatorDomain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Threading.Tasks;
using WebApi.Controllers;

namespace WebApiTest
{
    [TestClass]
    public class PersonControllerTests
    {
        private IMediator mediator;
        private PersonController controller;

        [TestInitialize]
        public void Init()
        {
            mediator = Substitute.For<IMediator>();
            controller = new PersonController(mediator);
        }

        [TestMethod]
        public async Task GetGreeting_Should_Return_Correct_Result()
        {
            var personId = 1;            
            mediator.Send(Arg.Any<GreetingsRequest>())
                .Returns(Task.FromResult(new GreetingsResponse { Greeting = $"Hello John" }));

            var response = await controller.GetGreeting(personId);
            var result = response.Result;

            result.Should().BeOfType<OkObjectResult>();     

            ((OkObjectResult)result).Value.Should().Be("Hello John");
        }


        [TestMethod]
        public async Task GetGreeting_Exception_Should_Return_400_BadRequest()
        {
            var personId = 1;
            mediator.Send(Arg.Any<GreetingsRequest>())
                .Returns<GreetingsResponse>(x => { throw new Exception(); });

            var response = await controller.GetGreeting(personId);
            var result = response.Result;

            result.Should().BeOfType<BadRequestObjectResult>();
        }
    }
}
