using System;
using System.Threading.Tasks;
using MediatorDomain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        // GET api/values/5
        [HttpGet("{personId}/greeting")]
        public async Task<ActionResult<string>> GetGreeting(int personId)
        {
            try
            {
                var request = new GreetingsRequest { PersonId = personId };
                var response = await mediator.Send(request);
                return Ok(response.Greeting);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/values
        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Value";
        }
    }
}
