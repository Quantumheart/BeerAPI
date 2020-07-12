using System.Threading.Tasks;
using BeerAPI.Commands.Brewery;
using BeerAPI.Queries.BreweryQueries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace BeerAPI.Controllers
{
    [ApiController]
    [Route("breweries")]
    public class BreweryController : Controller
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await Mediator.Send(request: new GetAllBreweriesQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrewery(int id)
        {
            var query = new GetBreweryQuery() {Id = id};
            return Ok(await Mediator.Send(query));
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateBrewery([FromBody] CreateBreweryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBrewery([FromBody] DeleteBreweryCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}